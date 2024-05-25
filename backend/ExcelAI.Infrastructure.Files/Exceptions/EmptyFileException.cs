using Microsoft.AspNetCore.Http;

namespace ExcelAI.Infrastructure.Files.Exceptions
{
    public class EmptyFileException : Exception
    {
        public EmptyFileException(IFormFile file) : 
            base(message: $"File '{file.FileName}' was empty. File length = {file.Length}") { }
    }
}
