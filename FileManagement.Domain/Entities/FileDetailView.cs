using System;
using FileManagement.Domain.Common;

namespace FileManagement.Domain.Entities
{
    public class FileDetailView : AuditableEntity
    {
        public FileDetailView()
        {
            
        }
        public FileDetailView(string fileName, string uniqueFileName, long fileSize)
        {
            UniqueFileName = uniqueFileName;
            FileName = fileName;
            FileSize = fileSize;
        }

        public Guid Id { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string UniqueFileName { get; set; }
    }
}