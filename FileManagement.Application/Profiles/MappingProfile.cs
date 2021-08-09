using AutoMapper;
using FileManagement.Application.Features.File.Queries.GetFileList;
using FileManagement.Domain.Entities;

namespace FileManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FileDetailView, FileListDto>().ReverseMap();
            CreateMap<FileDetailView, FileListVm>().ReverseMap();
        }
    }
}