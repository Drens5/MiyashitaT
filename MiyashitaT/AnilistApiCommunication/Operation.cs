using Newtonsoft.Json;
using MiyashitaT.AnilistApiCommunication.Datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiyashitaT.AnilistApiCommunication
{
    /// <summary>
    /// Class defines all functionality and relevancy of doing a GraphQL service operation with anilist's Api.
    /// </summary>
    public static class Operation
    {
        private static readonly HttpClient client = new HttpClient();


        static Operation()
        {
            client.BaseAddress = new Uri("https://graphql.anilist.co");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// Makes a (Json) post request accounting for the Rate Limiting to the anilist Api.
        /// </summary>
        /// <param name="requestBody">Json body to be sent with the request.</param>
        /// <returns>The response of the request made.</returns>
        /// <remarks>May throw an HttpRequestException.</remarks>
        private static async Task<HttpResponseMessage> SafeRequest(StringContent requestBody, StringContent requestBodyForRetry)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, requestBody).ConfigureAwait(false);

                // Account of Rate-Limiting.
                // Doing a request takes about 730ms, only in debug.
                if (response.Headers?.RetryAfter?.Delta != null)
                {

                    // Wait for the specified amount of time.
                    int waitTimeInMilliseconds = (int)Math.Ceiling(response.Headers.RetryAfter.Delta.Value.TotalMilliseconds);
                    Thread.Sleep(waitTimeInMilliseconds);

                    // Retry request after waiting.
                    response = await client.PostAsync(client.BaseAddress, requestBodyForRetry).ConfigureAwait(false);
                }
                response.EnsureSuccessStatusCode();

                return response;
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        /// <summary>
        /// Makes a request and deserializes the response to a TopLevel object.
        /// </summary>
        /// <param name="requestBody">Request body to send as Json.</param>
        /// <returns>Response as a TopLevel object.</returns>
        private static async Task<TopLevel> SafeRequestAndDeserializeResponse(StringContent requestBody, StringContent requestBodyForRetry)
        {
            HttpResponseMessage response = await SafeRequest(requestBody, requestBodyForRetry).ConfigureAwait(false);
            string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            TopLevel responseObject = JsonConvert.DeserializeObject<TopLevel>(responseBody, new Newtonsoft.Json.Converters.StringEnumConverter());
            return responseObject;
        }

        /// <summary>
        /// Serializes the service, prepares request body and handles retry of request body upon exceeded rate limit.
        /// </summary>
        /// <param name="service">GraphQL Service operation to be made.</param>
        /// <returns>Response as a TopLevel object.</returns>
        /// <remarks>
        /// When calling this e.g. in a UI app one would rather want to use .ConfigureAwait(true) since UI components can
        /// only be modified from the UI thread. But in terms of this library it's fine for continuation to be in a different thread.
        /// </remarks>
        public static async Task<TopLevel> SerializeMakeSafeRequestAndDeserializeResponse(Service service)
        {
            string serializedService = JsonConvert.SerializeObject(service, new Newtonsoft.Json.Converters.StringEnumConverter());
            StringContent requestBody = new StringContent(serializedService, Encoding.UTF8, "application/json");
            StringContent requestBodyForRetry = new StringContent(serializedService, Encoding.UTF8, "application/json");

            TopLevel responseObject = await SafeRequestAndDeserializeResponse(requestBody, requestBodyForRetry).ConfigureAwait(false);
            return responseObject;
        }
    }
}
