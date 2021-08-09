using FluentValidation;

namespace FileManagement.Application.Features.File.Command
{
    public class UploadFileCommandValidator : AbstractValidator<UploadFileCommand>
    {
        public UploadFileCommandValidator()
        {
            RuleFor(x => x.FileSize).GreaterThan(0).WithMessage("Invalid file size");
            RuleFor(x => x.FileName).NotNull().NotEmpty().WithMessage("File name cannot be null or empty");
        }
    }
}