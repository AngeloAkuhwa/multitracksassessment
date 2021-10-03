using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using MTBusinessLogic.Contract;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace MTBusinessLogic.Implementation
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        private readonly string pictureSize;

        public CloudinaryService()
        {
            pictureSize = ConfigurationManager.AppSettings["PictureSize"];
           
            _cloudinary = new Cloudinary(new Account(ConfigurationManager.AppSettings["cloudName"],
                ConfigurationManager.AppSettings["apiKey"], ConfigurationManager.AppSettings["apiSecret"]));
        }


        public async Task<UploadResult> UploadImage(IFormFile model)
        {
            bool pictureFormat = false;

            List<string> listOfPhotoExtensions = GetPhotoExtensions();

            for (int i = 0; i < listOfPhotoExtensions.Count; i++)
            {
                var ele = model.FileName.ToLower();
                if (ele.EndsWith(listOfPhotoExtensions[i]))
                {
                    pictureFormat = true;
                    break;
                }
            }

            if (!pictureFormat || model == null) throw new ApplicationException("picture format not supported");

            if (model.Length > Convert.ToInt64(pictureSize)) throw new ApplicationException("photo is greater than 5mb");

            ImageUploadResult uploadResult;

            //fetch image as a stream of data

            var imageStream = model.OpenReadStream();
            {
                var fileName = Guid.NewGuid().ToString() + "_" + model.Name;

                ImageUploadParams imageUploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileName, imageStream),

                    Transformation = new Transformation().Crop("thumb")
                                                        .Gravity("face")
                                                        .Width(1000)
                                                        .Height(1000)
                                                        .Radius(40)
                };

                uploadResult = await _cloudinary.UploadAsync(imageUploadParams);
            }

            return uploadResult;

        }
        public async Task<DelResResult> DeleteImage(string publicId)
        {
            DelResParams deleteParams = new DelResParams
            {
                PublicIds = new List<string> { publicId },
                All = true,
                Invalidate = true,
                KeepOriginal = false
            };

            var result = await _cloudinary.DeleteResourcesAsync(deleteParams);

            return result;
        }

        private List<string> GetPhotoExtensions()
        {
            List<string> listOfPhotoExtensions = new List<string>();
            listOfPhotoExtensions.Add(ConfigurationManager.AppSettings["PhotoSettings:Extensions.Jpg"]);
            listOfPhotoExtensions.Add(ConfigurationManager.AppSettings["PhotoSettings:Extensions.Jpeg"]);
            listOfPhotoExtensions.Add(ConfigurationManager.AppSettings["PhotoSettings:Extensions.png"]);
            return listOfPhotoExtensions;
        }

        public async Task<UploadResult> UploadImageStream(Stream image, string fileLength)
        {
            
            ImageUploadResult uploadResult;

            //fetch image as a stream of data

            var imageStream = image;
            {
                var fileName = fileLength;

                ImageUploadParams imageUploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileName, imageStream),

                    Transformation = new Transformation().Crop("thumb")
                                                        .Gravity("face")
                                                        .Width(1000)
                                                        .Height(1000)
                                                        .Radius(40)
                };

                uploadResult = await _cloudinary.UploadAsync(imageUploadParams);
            }

            return uploadResult;

        }
    }
}
