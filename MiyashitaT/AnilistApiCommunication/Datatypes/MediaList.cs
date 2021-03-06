﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiyashitaT.AnilistApiCommunication.Datatypes
{
    /// <summary>
    /// Class defines a field in Json response of type MediaList.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class MediaList
    {
        private readonly MediaListStatus? status;
        private readonly Media media;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int progress;
        
        public MediaList(Media media, MediaListStatus? status, int progress)
        {
            this.status = status;
            this.media = media;
            this.progress = progress;
        }

        public MediaListStatus? Status => status;
        public Media Media => media;
        public int Progress => progress;
    }
}
