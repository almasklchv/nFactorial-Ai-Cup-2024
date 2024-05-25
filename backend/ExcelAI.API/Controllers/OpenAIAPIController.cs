using ExcelAI.API.Requests.OpenAI;
using ExcelAI.Domain.DataTable;
using ExcelAI.Domain.Excel;
using ExcelAI.Infrastructure.ExternalServices.OpenAI;
using ExcelAI.Infrastructure.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExcelAI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenAIAPIController : ControllerBase
    {
        private readonly ILogger<OpenAIAPIController> logger;
        private readonly IOpenAIService openAIService;
        private readonly IFileRepository fileRepository;
        private readonly IExcelService excelService;

        public OpenAIAPIController(ILogger<OpenAIAPIController> logger, 
                                    IOpenAIService openAIService, 
                                    IFileRepository fileRepository,
                                    IExcelService excelService)
        {
            this.logger = logger;
            this.openAIService = openAIService;
            this.fileRepository = fileRepository;
            this.excelService = excelService;
        }

        [HttpGet]
        public async Task<IResult> AreYouAlive()
        {
            return Results.Ok("I am alive");
        }


        [HttpPost("tableFromImages")]
        public async Task<IActionResult> GetTableFromImages([FromForm]TableFromImagesRequest request)
        {
            if (request.Images.Count() == 0)
            {
                return BadRequest("No images sent");
            }
            return await this.FormTableFromImagesAsync(request);
        }

        [HttpPost("tableFromImagesWithHeaders")]
        public async Task<IActionResult> GetTableFromImagesWithHeaders([FromForm] TableFromImagesWithSpecifiedHeaders request)
        {
            if(request.Headers.Count() == 0)
            {
                return await this.FormTableFromImagesAsync(
                    new TableFromImagesRequest() 
                    { 
                        Images = request.Images
                    });
            };

            if (request.Images.Count() == 0)
            {
                return BadRequest("No images sent");
            }

            return await this.FormTableFromImagesWithHeadersAsync(request);
        }

        //TODO: 
        //  0) CopyPaste remove - mb new method? new service?

        private async Task<FileContentResult> FormTableFromImagesAsync(TableFromImagesRequest request)
        {
            var savedImages = await this.fileRepository.SaveFilesAsync(request.Images);
            DataTable openAIResult = await this.openAIService.GetDataTableFromImages(savedImages, null);
            await this.fileRepository.RemoveFilesAsync(savedImages);

            IWorkbook workbook = this.excelService.FromCSV(openAIResult);
            var workBookFilePath = workbook.FileInfo.FullName;

            byte[] fileBytes = this.fileRepository.ReadBytes(workBookFilePath);
            await this.fileRepository.RemoveFilesAsync(workBookFilePath);
            string mimeType = "application/octet-stream";

            return File(fileBytes, mimeType, workbook.FileInfo.Name);
        }
        private async Task<FileContentResult> FormTableFromImagesWithHeadersAsync(TableFromImagesWithSpecifiedHeaders request)
        {
            var savedImages = await this.fileRepository.SaveFilesAsync(request.Images);
            DataTable openAIResult = await this.openAIService.GetDataTableFromImagesWithSpecifiedHeaders(request.Headers, savedImages, null);
            await this.fileRepository.RemoveFilesAsync(savedImages);

            IWorkbook workbook = this.excelService.FromCSV(openAIResult);
            var workBookFilePath = workbook.FileInfo.FullName;

            byte[] fileBytes = this.fileRepository.ReadBytes(workBookFilePath);
            await this.fileRepository.RemoveFilesAsync(workBookFilePath);
            string mimeType = "application/octet-stream";

            return File(fileBytes, mimeType, workbook.FileInfo.Name);
        }
    }
}
