using ExcelAI.Infrastructure.Files.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ExcelAI.Infrastructure.Files
{
    public class FileRepository : IFileRepository
    {
        private readonly ILogger<IFileRepository> logger;
        private readonly IConfiguration configuration;
        private readonly string storagePath;
        
        public FileRepository(IConfiguration configuration,
                              ILogger<IFileRepository> logger)
        {
            this.configuration = configuration;
            this.storagePath = this.configuration["FileStorage:Path"]
                ?? throw new NoStorageRootFoundException();

            this.logger = logger;
        }

        public async Task<IEnumerable<FileInfo>> SaveFilesAsync(IEnumerable<IFormFile> formFiles)
        {
            List<FileInfo> savedFiles = new List<FileInfo>(formFiles.Count());

            if (!Directory.Exists(storagePath))
            {
                this.CreateDir(storagePath);
            }

            foreach(IFormFile file in formFiles)
            {
                if (FileIsEmpty(file))
                {
                    throw new EmptyFileException(file);
                }

                var savedFile = await this.WriteFile(file, this.storagePath);
                savedFiles.Add(savedFile);
            }
            return savedFiles;
        }
        public Task<IEnumerable<FileInfo>> SaveFilesAsync(params IFormFile[] formFiles)
            => this.SaveFilesAsync(formFiles);

        public Task RemoveFilesAsync(IEnumerable<FileInfo> files)
        {
            return Task.Run(() =>
            {
                Parallel.ForEach(files, file =>
                {
                    File.Delete(file.FullName);
                });
            });
        }
        public Task RemoveFilesAsync(params FileInfo[] files)
            => this.RemoveFilesAsync(files.AsEnumerable());
        public Task RemoveFilesAsync(IEnumerable<string> paths)
        {
            List<FileInfo> files = new List<FileInfo>(paths.Count());
            foreach(string path in paths)
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException(path);
                }
                files.Add(new FileInfo(path));
            }
            return this.RemoveFilesAsync(files);
        }
        public Task RemoveFilesAsync(params string[] paths)
            => this.RemoveFilesAsync(paths.AsEnumerable());

        public void RemoveFiles(IEnumerable<FileInfo> files)
        {
            foreach(FileInfo file in files)
            {
                File.Delete(file.FullName);
            }
        }
        public void RemoveFiles(params FileInfo[] files)
            => this.RemoveFiles(files.AsEnumerable());
        public void RemoveFiles(IEnumerable<string> paths)
        {
            List<FileInfo> files = new List<FileInfo>(paths.Count());
            foreach (string path in paths)
            {
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException(path);
                }
                files.Add(new FileInfo(path));
            }
            this.RemoveFiles(files);
        }
        public void RemoveFiles(params string[] paths)
            => this.RemoveFiles(paths.AsEnumerable());

        public byte[] ReadBytes(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllBytes(path);
            }
            throw new FileNotFoundException(path);
        }
        public async Task<byte[]> ReadBytesAsync(string path)
        {
            if (File.Exists(path))
            {
                return await File.ReadAllBytesAsync(path);
            }
            throw new FileNotFoundException(path);
        }

        private async Task<FileInfo> WriteFile(IFormFile formFile, string fileStoragePath)
        {
            var fileName = formFile.FileName;
            var filePath = Path.Combine(fileStoragePath, fileName);

            using (var stream = File.Create(filePath))
            {
                await formFile.CopyToAsync(stream);
            }
            return new FileInfo(filePath);
        }

        private bool FileIsEmpty(IFormFile file)
        {
            return file.Length == 0;
        }

        private void CreateDir(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
