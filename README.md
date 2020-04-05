# MiyashitaT
Public API communication library for anime metadata originally made for use in NiitokiK and originally extracted from ReBoogiepopT.

## Anilist API Communication
The public method called `SerializeMakeSafeRequestAndDeserializeResponse` in `Operation.cs` is that which to use for API communication.

To properly use this library one needs to do the following:  
1. Include the namespace `MiyashitaT.AnilistApiCommunication`.

2. Create a GraphQL service.  
One does so by first creating a GraphQL query (string) and optionally an object which holds the necessary variables for that query.
There are a few sample classes defined in `Service.cs` that can be instantiated to be used as a variables object.
Then create a new Service object `Service service = new Service(query, variables)` or `Service service = new Service(query)`, one may view the details in `Service.cs`.  
**Remark**: When defining one's own classes to create objects from to use as variables for the query be sure to add the [JsonObject(MemberSerialization.Fields)] attribute which requires Newtonsoft.Json.

3. Do the request.  
Call `await SerializeMakeSafeRequestAndDeserializeResponse(service);` on the service that was created in step 2.  
**Remark**: This method may throw an HttpRequestException.

4. Parse the response to your desires.  
The response will be deserialized immediately upon being received.
Make sure in advance that all the fields that you query for are accounted for as anilist datatypes, for at this moment not all fields are set up to be deserialized; check in `Datatypes/*.cs`.
Or rather let me know what you wish to query for and I can show you how to make sure the fields are set up to be deserialized.
The way the response object works is as follows. The most upper json object is deserialized to the TopLevel datatype.
From there the data field is deserialized to the Data property, after which the anilist datatypes are accessible by a property with a backing field corresponding to the field in the json object.