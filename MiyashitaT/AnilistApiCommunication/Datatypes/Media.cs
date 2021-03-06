﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiyashitaT.AnilistApiCommunication.Datatypes
{
    /// <summary>
    /// Class defines media field in Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class Media
    {
        private readonly int id;
        private readonly int? idMal;
        private readonly MediaTitle title;
        private readonly MediaFormat? format;
        private readonly MediaStatus? status;
        private readonly string description;
        private readonly string siteUrl;
        private readonly MediaSeason? season;
        private readonly int? seasonYear;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int duration;

        private readonly MediaCoverImage coverImage;
        private readonly List<string> genres;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int meanScore;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        private readonly int popularity;

        private readonly List<MediaTag> tags;
        private readonly bool? isAdult;

        public int Id => id;
        public int? IdMal => idMal;
        public MediaTitle Title => title;
        public MediaFormat? Format => format;
        public MediaStatus? Status => status;
        public string Description => description;
        public string SiteUrl => siteUrl;
        public MediaSeason? Season => season;
        public int? SeasonYear => seasonYear;
        public int? Duration => duration;
        public MediaCoverImage CoverImage => coverImage;
        public List<string> Genres => genres;
        public int? MeanScore => meanScore;
        public int? Popularity => popularity;
        public List<MediaTag> Tags => tags;
        public bool? IsAdult => isAdult;
    }
}
