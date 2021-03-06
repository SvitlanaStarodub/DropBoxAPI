﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class AddFileRequestDto
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("mode")]
        public string Mode { get; set; }
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; }
        [JsonProperty("mute")]
        public bool Mute { get; set; }
        [JsonProperty("strict_conflict")]
        public bool StrictConflict { get; set; }
    }
}
