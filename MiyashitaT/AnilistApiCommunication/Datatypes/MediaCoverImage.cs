using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiyashitaT.AnilistApiCommunication.Datatypes
{
    /// <summary>
    /// Class defines a field of type MediaCoverImage in Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaCoverImage
    {
        private readonly string extraLarge;
        private readonly string large;
        private readonly string medium;

        public string ExtraLarge => extraLarge;
        public string Large => large;
        public string Medium => medium;
    }
}
