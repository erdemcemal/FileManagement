using System.IO;
using System.Threading.Tasks;
using FileManagement.Application.Contracts;
using Microsoft.Extensions.Configuration;

namespace FileManagement.Persistence.FileOperations
{
    public class FileSystemStorageProvider : IFileStorageProvider
    {
        private readonly IConfiguration _configuration;

        public FileSystemStorageProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Store(byte[] stream, string fileName)
        {
            var path = _configuration["FileSettings:Path"];
            string pathCombine = Path.Combine(path, fileName);
            //If directory is not exist than it will create auto
            Directory.CreateDirectory(path);
            await File.WriteAllBytesAsync(pathCombine, stream);
        }
    }
}