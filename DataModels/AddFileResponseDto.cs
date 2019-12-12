﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class AddFileResponseDto
    {
        public string Name { get; set; }
        [JsonProperty("path_lower")]
        public string PathLower { get; set; }
        [JsonProperty("path_display")]
        public string PathDisplay { get; set; }
        public string Id { get; set; }
        [JsonProperty("client_modified")]
        public DateTime ClientModified { get; set; }
        [JsonProperty("server_modified")]
        public DateTime ServerModified { get; set; }
        public string Rev { get; set; }
        public uint Size { get; set; }
        [JsonProperty("is_downloadable")]
        public bool IsDownloadable { get; set; }
        [JsonProperty("content_hash")]
        public string ContentHash { get; set; }
    }
}
