using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Helpers
{
    public static class FileManager
    {
        public async static Task<string> ImageUpload(this IFormFile formFile, string envpath, params string[] folders)
        {
            string uploadPath = envpath;
            string path = string.Empty;
            foreach (string folder in folders)
            {
                path = Path.Combine(path, folder);
            }
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }
            uploadPath = uploadPath + "/" + path;
            string filename = Path.GetFileNameWithoutExtension(formFile.FileName);
            filename = filename + Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            string mainPath = uploadPath + filename;
            using var stream = new FileStream(mainPath, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return filename;
        }
    }
}
