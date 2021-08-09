using FluentValidation;

namespace FileManagement.Application.Features.File.Queries.DownloadFile
{
    public class DownloadFileQueryHandlerValidator : AbstractValidator<DownloadFileQuery>
    {
        public DownloadFileQueryHandlerValidator()
        {
            RuleFor(x => x.UniqueFileName).NotNull().NotEmpty().WithMessage("File name cannot be empty or null");
        }
    }
}