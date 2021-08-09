using System;

namespace FileManagement.Application.Features.File.Queries.GetFileList
{
    public class FileListDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UniqueFileName { get; set; }
        public string PublicAccessUrl { get; set; }
    }
}