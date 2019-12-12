using System;
using DropBoxAPI.Client;
using DropBoxAPI.DataModels;
using FluentAssertions;
using Xunit;

namespace DropBoxAPITests
{
    public class CreateFolderTests : IDisposable
    {
        private const string BaseUrl = "https://api.dropboxapi.com";
        private const string FolderPath = "/TestRun1";
        private readonly DropBoxClient _dropBoxClient;

        public CreateFolderTests()
        {
            _dropBoxClient = new DropBoxClient(BaseUrl);
        }

        [Fact]
        public void CreateFolder()
        {
            //arrange
            var requestDto = new CreateFolderRequestDto
            {
                Path = FolderPath,
                AutoRename = false
            };

            var expectedResult = new CreateFolderResponseDto
            {
                MetaData = new MetaData        
                {
                    Name = FolderPath.TrimStart('/'),
                    PathLower = FolderPath.ToLower(),
                    PathDisplay = FolderPath
                }
            };

            //act
            var result = _dropBoxClient.CreateFolder(requestDto);
            
            //assert
            result.MetaData.Should().BeEquivalentTo(expectedResult.MetaData, cfg => cfg.Excluding(r => r.Id));
        }

        public void Dispose()
        {
            _dropBoxClient.DeleteFolder(new DeleteFolderRequestDto {Path = FolderPath});
        }
    }
}
