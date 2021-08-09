using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FileManagement.Application.Contracts.Persistence;
using FileManagement.Application.Features.File.Command;
using FileManagement.Application.Features.File.Queries.GetFileList;
using FileManagement.Application.Profiles;
using FileManagement.Application.UnitTests.Mocks;
using FileManagement.Domain.Entities;
using Moq;
using Shouldly;
using Xunit;

namespace FileManagement.Application.UnitTests.File.Queries
{
    public class GetFileListQueryHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IAsyncRepository<FileDetailView>> _mockFileRepository;

        public GetFileListQueryHandlerTests()
        {
            _mockFileRepository = RepositoryMocks.GetFileRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configurationProvider.CreateMapper();
        }
        
        [Fact]
        public async Task GetFileListTest()
        {
            var handler = new GetFileListQueryHandler(_mockFileRepository.Object, _mapper);

            var result = await handler.Handle(new GetFileListQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<FileListVm>>();

            result.Count.ShouldBe(4);
        }

        [Fact]
        public async Task Upload_EmptyFile_ReturnFalse()
        {
            string fileName = "test.txt";
            var fileContent = Encoding.ASCII.GetBytes("");
            

            var handler = new UploadFileCommandHandler(_mockFileRepository.Object, null);
            
            var result = await handler.Handle(new UploadFileCommand(fileContent, fileName, 0), CancellationToken.None);

            result.Success = false;
        }
        
        [Fact]
        public async Task Upload_EmptyFileName_ReturnFalse()
        {
            string fileName = null;
            var fileContent = Encoding.ASCII.GetBytes("test test ");
            

            var handler = new UploadFileCommandHandler(_mockFileRepository.Object, null);
            
            var result = await handler.Handle(new UploadFileCommand(fileContent, fileName, 0), CancellationToken.None);

            result.Success = false;
        }
        
        
    }
}