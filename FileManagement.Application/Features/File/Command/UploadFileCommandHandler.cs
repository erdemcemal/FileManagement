using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using FileManagement.Application.Contracts;
using FileManagement.Application.Contracts.Persistence;
using FileManagement.Domain.Entities;
using MediatR;

namespace FileManagement.Application.Features.File.Command
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadFileCommandResponse>
    {
        private readonly IAsyncRepository<FileDetailView> _fileRepository;
        private readonly IFileStorageProvider _fileStorageProvider;

        public UploadFileCommandHandler(IAsyncRepository<FileDetailView> fileRepository,
            IFileStorageProvider fileStorageProvider)
        {
            _fileRepository = fileRepository;
            _fileStorageProvider = fileStorageProvider;
        }

        public async Task<UploadFileCommandResponse> Handle(UploadFileCommand request,
            CancellationToken cancellationToken)
        {
            var uploadFileCommandResponse = new UploadFileCommandResponse();

            var validator = new UploadFileCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
            {
                uploadFileCommandResponse.Success = false;
                uploadFileCommandResponse.ValidationErrors = new List<string>();
                foreach (var validationFailure in validationResult.Errors)
                {
                    uploadFileCommandResponse.ValidationErrors.Add(validationFailure.ErrorMessage);
                }
            }

            if (!uploadFileCommandResponse.Success) return uploadFileCommandResponse;

            var ext = Path.GetExtension(request.FileName);
            var uniqueFileName = Path.GetRandomFileName() + ext;
            await _fileStorageProvider.Store(request.Content, uniqueFileName);

            await _fileRepository.AddAsync(new FileDetailView(request.FileName, uniqueFileName, request.FileSize));


            return uploadFileCommandResponse;
        }
    }
}