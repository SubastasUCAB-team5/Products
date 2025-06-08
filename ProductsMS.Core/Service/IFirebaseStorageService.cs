using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ProductMS.Core.Service
{
    public interface IFirebaseStorageService
    {

        Task<string> UploadImageAsync(Stream fileStream, string fileName);
        
        Task<List<string>> UploadMultipleImagesAsync(Dictionary<string, Stream> files);
        
    }
}
