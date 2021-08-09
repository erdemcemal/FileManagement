using System.Collections.Generic;

namespace FileManagement.Application.Features.File.Queries.GetFileList
{
    public class PagedFileListVm
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<FileListDto> FileList { get; set; }
    }
}