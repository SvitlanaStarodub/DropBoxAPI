using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class FoldersResponseDto
    {
        public List<Entry> Entries { get; set; }

        [JsonProperty("cursor")]
        public string Cursor { get; set; }

        [JsonProperty("has_more")]
        public string HasMore { get;set;}
    }
    public class Entry
    {
        //[JsonProperty(".tag")]
        //public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path_lower")]
        public string PathLower { get; set; }

        //[JsonProperty("path_display")]
        //public string IncludeMediaInfo { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("client_modified")]
        public string ClientModified { get; set; }

        [JsonProperty("server_modified")]
        public string ServerModified { get; set; }

        [JsonProperty("rev")]
        public string Rev { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("is_downloadable")]
        public string IsDownloadable { get; set; }

        [JsonProperty("content_hash")]
        public string ContentHash { get; set; }
    }
}
