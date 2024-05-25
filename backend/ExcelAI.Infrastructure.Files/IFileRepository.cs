using Microsoft.AspNetCore.Http;

namespace ExcelAI.Infrastructure.Files
{
    public interface IFileRepository
    {
        public Task<IEnumerable<FileInfo>> SaveFilesAsync(IEnumerable<IFormFile> formFiles);
        public Task<IEnumerable<FileInfo>> SaveFilesAsync(params IFormFile[] formFiles);

        public Task RemoveFilesAsync(IEnumerable<FileInfo> files);
        public Task RemoveFilesAsync(params FileInfo[] files);
        public Task RemoveFilesAsync(IEnumerable<string> paths);
        public Task RemoveFilesAsync(params string[] paths);

        public void RemoveFiles(IEnumerable<FileInfo> files);
        public void RemoveFiles(params FileInfo[] files);
        public void RemoveFiles(IEnumerable<string> paths);
        public void RemoveFiles(params string[] paths);



        public byte[] ReadBytes(string path);
        public Task<byte[]> ReadBytesAsync(string path);
    }
}
