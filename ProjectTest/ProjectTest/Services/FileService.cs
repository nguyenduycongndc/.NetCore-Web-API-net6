using Microsoft.AspNetCore.Hosting;
using ProjectTest.Common;
using ProjectTest.Model;
using ProjectTest.Repo;
using ProjectTest.Repo.Interface;
using ProjectTest.Services.Interface;
using System.Net.Http.Headers;

namespace ProjectTest.Services
{
    public class FileService : IFileService
    {
        private readonly ILogger<FileService> _logger;
        private readonly IFileRepo _fileRepo;
        private ResultModel Result;
        public readonly string _contentFolder;
        public const string CONTEN_FOLDER_NAME = "UploadFile";
        public FileService(IFileRepo fileRepo, ILogger<FileService> logger, IWebHostEnvironment webHostEnvironment)
        {
            _fileRepo = fileRepo;
            _logger = logger;
            _contentFolder = Path.Combine(webHostEnvironment.WebRootPath, CONTEN_FOLDER_NAME);
        }
        public async Task SaveFileAsync(Stream mediaBinaryStrem, string fileName)
        {
            try
            {
                var filePath = Path.Combine(_contentFolder, fileName);// lay link
                using var output = new FileStream(filePath, FileMode.Create);// laay thu muc luu file
                await mediaBinaryStrem.CopyToAsync(output);//day file vao thu muc
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task DeleteFileAync(string fileName)
        {
            try
            {
                var filePath = Path.Combine(_contentFolder, fileName);

                if (File.Exists(filePath))
                {
                    await Task.Run(() => File.Delete(filePath));
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<SaveFiModel> SaveFile(IFormFile file)
        {
            try
            {
                var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var sizeFile = file.Length;
                await SaveFileAsync(file.OpenReadStream(), originalFileName);
                return new SaveFiModel()
                {
                    OriginalFileName = originalFileName,
                    FileName = $"/{CONTEN_FOLDER_NAME}/{originalFileName}",
                    SizeFile = sizeFile
                };
            }
            catch (Exception e)
            {
                throw;
            }
            
        }

        public async Task<ResultModel> AddFileOrder(Upfile fileModel, CurrentUserModel _userInfo)//lay model
        {
            try
            {
                var detailFile = await SaveFile(fileModel.File);

                //if (fileModel.File != null)
                //{
                //    fileModel.Path = detailFile.FileName;
                //    fileModel.Name = detailFile.OriginalFileName;
                //}
                DataUpfile usfi = new DataUpfile()
                {
                    Name = detailFile.OriginalFileName,
                    Path = detailFile.FileName,
                    File = fileModel.File,
                    UserId = _userInfo.Id,
                };
                var rs = await _fileRepo.AddNewFile(usfi);
                Result = new ResultModel()
                {
                    Data = rs == true ? new SaveFiModel()
                    {
                        OriginalFileName = detailFile.OriginalFileName,
                        FileName = detailFile.FileName,
                        SizeFile = detailFile.SizeFile
                    } : null,
                    Message = (rs == true ? "OK" : "Bad Request"),
                    Code = (rs == true ? 200 : 400),
                };
                return Result;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
