using MediatR;

namespace FileManagement.Application.Features.File.Queries.GetFileList
{
    public class GetPagedFileListQuery : IRequest<PagedFileListVm>
    {
        public int Page { get; set; }
        public int Size { get; set; }

        public GetPagedFileListQuery()
        {
        }

        public GetPagedFileListQuery(int page, int size)
        {
            Page = page;
            Size = size;
        }
    }
}