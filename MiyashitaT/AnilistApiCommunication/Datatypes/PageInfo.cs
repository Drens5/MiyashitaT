﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MiyashitaT.AnilistApiCommunication.Datatypes
{
    /// <summary>
    /// Class defines pageInfo field from a Json response.
    /// </summary>
    [JsonObject(MemberSerialization.Fields)]
    public class PageInfo
    {
        private readonly int currentPage;
        private readonly int lastPage;
        private readonly bool hasNextPage;

        public int CurrentPage => currentPage;
        public int LastPage => lastPage;
        public bool HasNextPage => hasNextPage;
    }
}
