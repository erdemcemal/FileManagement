using System.IO;
using System.Threading.Tasks;
using FileManagement.Api.Utilities;
using FileManagement.Application.Features.File.Command;
using FileManagement.Application.Features.File.Queries.DownloadFile;
using FileManagement.Application.Features.File.Queries.GetFileList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FileManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;


        public FileController(ILogger<FileController> logger, IMediator mediator, IConfiguration configuration)
        {
            _logger = logger;
            _mediator = mediator;
            _configuration = configuration;
        }

        [HttpPost("uploadFile", Name = "UploadFile")]
        public async Task<ActionResult> UploadStream(IFormFile file)
        {
            await using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            await _mediator.Send(new UploadFileCommand(ms.ToArray(), file.FileName, file.Length));
            return Ok();
        }

        [HttpGet("getAllFiles", Name = "GetAllFiles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get(int page = 1, int size = 50)
        {
            var dtos = await _mediator.Send(new GetPagedFileListQuery(page, size));
            return Ok(dtos);
        }

        [HttpGet("download/{fileName}", Name = "DownloadFile")]
        public async Task<FileResult> DownloadFile(string fileName)
        {
            var fileResult = await _mediator.Send(new DownloadFileQuery(fileName));
            var bytes = await GetFileContent(fileName);
            return File(bytes, "application/octet-stream", fileResult.FileName);
        }

        private async Task<byte[]> GetFileContent(string fileName)
        {
            var path = _configuration["FileSettings:Path"];
            string pathCombine = Path.Combine(path, fileName);

            byte[] bytes = await System.IO.File.ReadAllBytesAsync(pathCombine);
            return bytes;
        }
    }
}