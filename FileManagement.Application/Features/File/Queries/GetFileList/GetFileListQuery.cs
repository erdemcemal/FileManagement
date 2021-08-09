using System.Collections.Generic;
using MediatR;

namespace FileManagement.Application.Features.File.Queries.GetFileList
{
    public class GetFileListQuery : IRequest<List<FileListVm>>
    {
        
    }
}