using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class CreateFolderRequestDto
    {
        [JsonProperty("path")]
        public string Path { get; set; }
        [JsonProperty("autorename")]
        public bool AutoRename { get; set; }
    }
}
