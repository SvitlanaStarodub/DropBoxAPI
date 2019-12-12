using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DropBoxAPI.Client;
using DropBoxAPI.DataModels;
using FluentAssertions;
using FluentAssertions.Common;
using Xunit;

namespace DropBoxAPITests
{
    public class AddFileTest
    {
        private readonly DropBoxClient _dropBoxClient;
        private const string BaseUrl = "https://content.dropboxapi.com";
        private const string FilePath = "/CreatedForTest.txt";
        private const string FileName = "CreatedForTest.txt";

        public AddFileTest()
        {
            _dropBoxClient = new DropBoxClient(BaseUrl);
        }

        [Fact]
        public void AddFile()
        {
            //arrange
            var requestDto = new AddFileRequestDto
            {
                Path = FilePath,
                Mode = "overwrite",
                AutoRename = true,
                Mute = false,
                StrictConflict = false
            };
            var expectedResult = new AddFileResponseDto
            {
                Name = FileName,
                PathLower = FilePath.ToLower(),
                PathDisplay = FilePath
            };

            //act
            var result = _dropBoxClient.AddFile(requestDto, FileName);

            //assert
            result.Should().BeEquivalentTo(expectedResult, cfg=> cfg.Including(r => r.Name)
                                                                          .Including(r => r.PathDisplay)
                                                                          .Including(r => r.PathLower));



        }
    }
}
