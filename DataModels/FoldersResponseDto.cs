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

        
    }
    public class Entry
    {
        [JsonProperty(".tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path_lower")]
        public string PathLower { get; set; }

        [JsonProperty("path_display")]
        public string PathDisplay { get; set; }

        
    }
}
