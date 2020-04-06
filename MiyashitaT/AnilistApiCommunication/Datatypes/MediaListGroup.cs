using Newtonsoft.Json;
using System.Collections.Generic;

namespace MiyashitaT.AnilistApiCommunication.Datatypes
{
    /// <summary>
    /// Class describes a field of type MediaListGroup in a Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaListGroup
    {
        private readonly MediaListStatus? status;
        private readonly List<MediaList> entries;

        public MediaListStatus? Status => status;
        public List<MediaList> Entries => entries;
    }
}
