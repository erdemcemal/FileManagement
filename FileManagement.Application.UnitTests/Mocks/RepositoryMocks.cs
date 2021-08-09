using System;
using System.Collections.Generic;
using FileManagement.Application.Contracts.Persistence;
using FileManagement.Application.Features.File.Queries.GetFileList;
using FileManagement.Domain.Entities;
using Moq;

namespace FileManagement.Application.UnitTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IAsyncRepository<FileDetailView>> GetFileRepository()
        {
           var files = new List<FileDetailView>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    FileName = "test1.pdf",
                    FileSize = 71970,
                    CreatedDate = DateTime.Parse("2021-08-08 18:01:30.0181447"),
                    UniqueFileName = "v505cv41.gy4.pdf",
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FileName = "test2.pdf",
                    FileSize = 125506,
                    CreatedDate = DateTime.Parse("2021-08-08 20:36:27.3248693"),
                    UniqueFileName = "grwgwdd2.k2c.pdf",
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FileName = "test3.json",
                    FileSize = 4200,
                    CreatedDate = DateTime.Parse("2021-08-08 20:36:28.7045934"),
                    UniqueFileName = "usgpkbe1.z5k.json",
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    FileName = "test4.xlsx",
                    FileSize = 10478,
                    CreatedDate = DateTime.Parse("2021-08-08 20:36:28.7089534"),
                    UniqueFileName = "3emi0sxd.rzv.xlsx",
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<FileDetailView>>();
            mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(files);

            mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<FileDetailView>())).ReturnsAsync(
                (FileDetailView category) =>
                {
                    files.Add(category);
                    return category;
                });

            return mockCategoryRepository;
        }

    }
}