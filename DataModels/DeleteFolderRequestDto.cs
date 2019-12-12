using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class DeleteFolderRequestDto
    {
        [JsonProperty("path")]
        public string Path { get; set; }
    }
}
