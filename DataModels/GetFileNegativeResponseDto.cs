using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DropBoxAPI.DataModels
{
    public class ErrorResponse
    {
        public ErrorResponseDto ErrorResponseDto { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class ErrorResponseDto
    {
        [JsonProperty("error_summary")]
        public string ErrorSummary { get; set; }
    }


}
