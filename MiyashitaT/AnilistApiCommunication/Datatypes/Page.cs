﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiyashitaT.AnilistApiCommunication.Datatypes
{
    /// <summary>
    /// Class defines Page field in a Json respone.
    /// </summary>
    /// <remarks>Only one non-pageInfo field is allowed in a field of type Page.</remarks>
    /// <remarks>Activities is only for ListActivites.</remarks>
    [JsonObject(MemberSerialization.Fields)]
    public class Page
    {
        private readonly PageInfo pageInfo;
        private readonly List<ListActivity> activities;
        private readonly List<Media> media;

        public PageInfo PageInfo => pageInfo;
        public List<ListActivity> Activities => activities;
        public List<Media> Media => media;
    }
}
