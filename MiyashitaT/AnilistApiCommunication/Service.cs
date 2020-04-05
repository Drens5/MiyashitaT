using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiyashitaT.AnilistApiCommunication
{
    /// <summary>
    /// Empty class to pass into a service to make a GraphQL operation request without variables.
    /// </summary>
    [JsonObject()]
    public class Empty
    {

    }

    /// <summary>
    /// Class defines a possible variable field for a GraphQL operation request in which name of type string is provided.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Name
    {
        private readonly string name;

        public Name(string name)
        {
            this.name = name;
        }
    }

    /// <summary>
    /// Class defines a variable field for a GraphQL operation request in which a single id, called "id", is provided.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Id
    {
        private readonly int id;

        public Id(int id)
        {
            this.id = id;
        }
    }

    /// <summary>
    /// Class defines the object to be serialized in order to send a valid GraphQL operation request.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Service
    {
        private readonly string query;
        private readonly object variables;

        /// <summary>
        /// Create service with variables.
        /// </summary>
        /// <param name="query">GraphQL operation query.</param>
        /// <param name="variables">Variables for the operation query.</param>
        public Service(string query, object variables)
        {
            this.query = query;
            this.variables = variables;
        }

        /// <summary>
        /// Create service without variables.
        /// </summary>
        /// <param name="query">GraphQL operation query.</param>
        public Service(string query) : this(query, new Empty())
        {

        }
    }
}
