using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.UI.WebControls;
using DropBoxAPI.DataModels;
using Newtonsoft.Json;
using RestSharp;

namespace DropBoxAPI.Client
{
    public class DropBoxClient
    {
        private const string AccessToken = "DBtqFGCsEzAAAAAAAAACuZh4ZWdt1tp8C-rUooxmj3x208JFJbz_Eh4GQSIQfe7A";
        private readonly RestClient _restClient;
        
        public DropBoxClient()
        {
            _restClient = new RestClient();
        }

        public CreateFolderResponseDto CreateFolder(CreateFolderRequestDto createFolderRequestDto)
        {
            var request = new RestRequest("https://api.dropboxapi.com/2/files/create_folder_v2", Method.POST);
            AuthorizationHeaders(request);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(createFolderRequestDto));
            var response = _restClient.Execute<CreateFolderResponseDto>(request);
            
            if(!response.IsSuccessful)
                throw new Exception($"{response.StatusCode}-{response.ErrorMessage}");

            return response.Data;
        }

        public ErrorResponse CreateFolderNegative(CreateFolderRequestDto createFolderRequestDto)
        {
            var request = new RestRequest("https://api.dropboxapi.com/2/files/create_folder_v2", Method.POST);
            AuthorizationHeaders(request);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(createFolderRequestDto));
            var response = _restClient.Execute<ErrorResponseDto>(request);

            return new ErrorResponse
            {
                ErrorResponseDto = response.Data,
                StatusCode =  response.StatusCode
            };

        }

        public void DeleteFolder(DeleteFolderRequestDto deleteFolderRequestDto)
        {
            var request = new RestRequest("https://api.dropboxapi.com/2/files/delete_v2", Method.POST);
            AuthorizationHeaders(request);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(deleteFolderRequestDto));
            var response = _restClient.Execute(request);

            if (!response.IsSuccessful)
                throw new Exception($"{response.StatusCode}-{response.ErrorMessage}");
        }

        private void AuthorizationHeaders(RestRequest request)
        {
            request.AddHeader("Authorization", $"Bearer {AccessToken}");
            }

        public AddFileResponseDto AddFile(AddFileRequestDto addFileRequestDto, string fileName)
        {
            var request = new RestRequest("https://content.dropboxapi.com/2/files/upload", Method.POST);
            AuthorizationHeaders(request);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddHeader("data-binary", $"@{fileName}");
            request.AddHeader("Dropbox-API-Arg", JsonConvert.SerializeObject(addFileRequestDto));
            request.AddParameter("application/octet-stream", File.ReadAllBytes(fileName), ParameterType.RequestBody);

            var response = _restClient.Execute<AddFileResponseDto>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"{response.StatusCode} - {response.ErrorMessage}");
            }

            return response.Data;
        }

        public FoldersResponseDto GetFolder(FoldersRequestDto foldersRequestDto)
        {
            var request = new RestRequest("https://api.dropboxapi.com/2/files/list_folder", Method.POST);
            AuthorizationHeaders(request);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(JsonConvert.SerializeObject(foldersRequestDto));
            var response = _restClient.Execute<FoldersResponseDto>(request);

            if (!response.IsSuccessful)
            {
                throw new Exception($"{response.StatusCode} - {response.ErrorMessage}");
            }
            return response.Data;
        }

        public GetFileResponseDto GetFile(GetFileRequestDto getFileRequestDto)
        {
            var request = new RestRequest("https://content.dropboxapi.com/2/files/download", Method.POST);
            AuthorizationHeaders(request);
            request.AddHeader("Dropbox-API-Arg", JsonConvert.SerializeObject(getFileRequestDto));
            var response = _restClient.Execute<GetFileResponseDto>(request);
            if (!response.IsSuccessful)
            {
                throw new Exception($"{response.StatusCode} - {response.ErrorMessage}");
            }

            return response.Data;
        }
    }
}
