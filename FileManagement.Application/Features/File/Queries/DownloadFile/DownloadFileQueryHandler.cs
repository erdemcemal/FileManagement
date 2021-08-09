using System.Threading;
using System.Threading.Tasks;
using FileManagement.Application.Contracts.Persistence;
using FileManagement.Application.Exceptions;
using FileManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FileManagement.Application.Features.File.Queries.DownloadFile
{
    public class DownloadFileQueryHandler : IRequestHandler<DownloadFileQuery, FileResultVm>
    {
        private readonly IAsyncRepository<FileDetailView> _fileRepository;
        private readonly IConfiguration _configuration;

        public DownloadFileQueryHandler(IAsyncRepository<FileDetailView> fileRepository, IConfiguration configuration)
        {
            _fileRepository = fileRepository;
            _configuration = configuration;
        }

        public async Task<FileResultVm> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            var validator = new DownloadFileQueryHandlerValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var file = await _fileRepository.GetAsync(x => x.UniqueFileName == request.UniqueFileName);
            if (file is null)
            {
                throw new NotFoundException(nameof(FileDetailView), request.UniqueFileName);
            }
            return new FileResultVm {FileName = file.FileName};
        }
    }
}