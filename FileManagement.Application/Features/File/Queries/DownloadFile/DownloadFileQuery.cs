using MediatR;

namespace FileManagement.Application.Features.File.Queries.DownloadFile
{
    public class DownloadFileQuery : IRequest<FileResultVm>
    {
        public DownloadFileQuery(string uniqueFileName)
        {
            UniqueFileName = uniqueFileName;
        }

        public string UniqueFileName { get; set; }
    }
}