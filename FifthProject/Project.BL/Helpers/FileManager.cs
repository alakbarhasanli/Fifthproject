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
        public static async Task<string> ImageUpload(this IFormFile formFile,string envpath,params string[] folders)
        {
            string uploadPath = envpath;
            string path = string.Empty;
            foreach(var folder in folders)
            {
                path = Path.Combine(path, folder);
            }
            if(!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath  );
            }
            uploadPath = uploadPath + "/" + path;
            string filename = Path.GetFileNameWithoutExtension(formFile.FileName);
            if(filename.Length>50)
            {
                filename.Substring(0, 79);
            }
            filename = filename + Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            string MainPath = uploadPath + filename;
            using var stream = new FileStream(MainPath, FileMode.Create);
            await formFile.CopyToAsync(stream);
            return filename;
        }
    }
}
