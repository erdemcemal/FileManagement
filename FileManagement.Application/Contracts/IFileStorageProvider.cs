using System.Threading.Tasks;

namespace FileManagement.Application.Contracts
{
    public interface IFileStorageProvider
    {
        Task Store(byte[] stream, string fileName);
    }
}