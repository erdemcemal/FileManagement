using MediatR;

namespace FileManagement.Application.Features.File.Command
{
    public class UploadFileCommand : IRequest<UploadFileCommandResponse>
    {
        public UploadFileCommand(byte[] content, string fileName, long fileSize)
        {
            Content = content;
            FileName = fileName;
            FileSize = fileSize;
        }

        public byte[] Content { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
    }
}