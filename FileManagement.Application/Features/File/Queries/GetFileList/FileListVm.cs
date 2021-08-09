using System;

namespace FileManagement.Application.Features.File.Queries.GetFileList
{
    public class FileListVm
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string UniqueFileName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}