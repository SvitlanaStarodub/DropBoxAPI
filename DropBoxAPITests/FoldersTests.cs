using System.Collections.Generic;
using DropBoxAPI.Client;
using DropBoxAPI.DataModels;
using FluentAssertions;
using Xunit;

namespace DropBoxAPITests
{
    public class FoldersTests
    {
        private const string BaseUrl = "https://api.dropboxapi.com";
        private const string FolderPath = "/TestRun1";
        private const string FileName = "/CreatedForTest.txt";
        private const string PathDisplay = "/TestRun1/CreatedForTest.txt";
        private const string FilePath = "/CreatedForTest.txt";
        private readonly DropBoxClient _dropBoxClient;

        public FoldersTests()
        {
            _dropBoxClient = new DropBoxClient(BaseUrl);
            EnsureFolderExists(FolderPath);
            EnsureFileExists(FolderPath);
        }


        [Fact]
        public void GetFiles()
        {
            //arrange
            var requestDto = new FoldersRequestDto
            {
                Path = FolderPath,
                Recursive = false,
                IncludeMediaInfo = false,
                IncludeDeleted = false,
                IncludeHasExplicitSharedMemebers = false,
                IncludeMountedFolders = true,
                IncludeNonDownloadadbleFiles = true

            };
            var expectedResponse = new FoldersResponseDto()
            {

                Entries = new List<Entry>
                {
                    new Entry()
                    {
                        Tag = "file",
                        Name = FileName,
                        PathLower = PathDisplay.ToLower(),
                        PathDisplay = PathDisplay

                    }
                }
            };

            //act
            var result = _dropBoxClient.GetFolder(requestDto);
            //assert
            result.Should().BeEquivalentTo(expectedResponse.Entries);
        }

        private void EnsureFileExists(string FileName)
        {
            _dropBoxClient.AddFile(new AddFileRequestDto
            {
                
                    Path = FilePath,
                    Mode = "overwrite",
                    AutoRename = true,
                    Mute = false,
                    StrictConflict = false
            }, FileName);
        }
        private void EnsureFolderExists(string FolderPath)
        {
            _dropBoxClient.CreateFolder(new CreateFolderRequestDto
            {
                Path = FolderPath,
                AutoRename = false
            });
        }

        public void Dispose()
        {
            _dropBoxClient.DeleteFolder(new DeleteFolderRequestDto { Path = FolderPath });
        }

    }
}
