using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FileManagement.Application.Contracts.Persistence;
using FileManagement.Domain.Entities;
using MediatR;

namespace FileManagement.Application.Features.File.Queries.GetFileList
{
    public class GetFileListQueryHandler : IRequestHandler<GetFileListQuery, List<FileListVm>>
    {
        private readonly IAsyncRepository<FileDetailView> _asyncRepository;
        private readonly IMapper _mapper;

        public GetFileListQueryHandler(IAsyncRepository<FileDetailView> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<List<FileListVm>> Handle(GetFileListQuery request, CancellationToken cancellationToken)
        {
            var allFiles = (await _asyncRepository.ListAllAsync()).OrderByDescending(x => x.CreatedDate);
            return _mapper.Map<List<FileListVm>>(allFiles);
        }
    }
}