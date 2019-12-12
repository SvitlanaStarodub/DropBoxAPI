using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class FoldersRequestDto
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("recursive")]
        public bool Recursive { get; set; }

        [JsonProperty("include_media_info")]
        public bool IncludeMediaInfo { get; set; }

        [JsonProperty("include_deleted")]
        public bool IncludeDeleted { get; set; }

        [JsonProperty("include_has_explicit_shared_members")]
        public bool IncludeHasExplicitSharedMemebers { get; set; }

        [JsonProperty("include_mounted_folders")]
        public bool IncludeMountedFolders { get; set; }

        [JsonProperty("include_non_downloadable_files")]
        public bool IncludeNonDownloadadbleFiles { get; set; }

    }
}
