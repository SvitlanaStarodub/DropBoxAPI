using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class CreateFolderResponseDto
    {
       public MetaData MetaData { get; set; }
    }

    public class MetaData
    {
        public string Name { get; set; }
        [JsonProperty("path_lower")]
        public string PathLower { get; set; }
        [JsonProperty("path_display")]
        public string PathDisplay { get; set; }
        public string Id { get; set; }
    }
}
