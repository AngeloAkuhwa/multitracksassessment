using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace MTBusinessLogic.Contract
{
    public interface ICloudinaryService
    {
        Task<UploadResult> UploadImage(IFormFile model);

        Task<DelResResult> DeleteImage(string publicId);

        Task<UploadResult> UploadImageStream(Stream image, string fileLenght);
    }
}
