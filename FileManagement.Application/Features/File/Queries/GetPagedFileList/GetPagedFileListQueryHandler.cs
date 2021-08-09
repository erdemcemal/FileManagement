using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FileManagement.Application.Contracts.Persistence;
using FileManagement.Domain.Entities;
using MediatR;

namespace FileManagement.Application.Features.File.Queries.GetFileList
{
    public class GetPagedFileListQueryHandler : IRequestHandler<GetPagedFileListQuery, PagedFileListVm>
    {
        private readonly IAsyncRepository<FileDetailView> _fileRepository;
        private readonly IMapper _mapper;

        public GetPagedFileListQueryHandler(IAsyncRepository<FileDetailView> fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<PagedFileListVm> Handle(GetPagedFileListQuery request, CancellationToken cancellationToken)
        {
            var list = await _fileRepository.GetPagedResponseAsync(request.Page, request.Size);
            var files = _mapper.Map<List<FileListDto>>(list);

            var count = await _fileRepository.CountAsync();

            return new PagedFileListVm {Count = count, FileList = files, Page = request.Page, Size = request.Size};
        }
    }
}