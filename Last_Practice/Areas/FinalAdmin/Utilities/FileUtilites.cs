using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Last_Practice.Areas.FinalAdmin.Utilities
{
    public static class FileUtilites
    {
        public static async Task<string> FileCreate(this IFormFile file, string root, string folder)
        {
            string filename = Guid.NewGuid() +  file.FileName;
            string path = Path.Combine(root,folder);
            string fullpath = Path.Combine(path, filename);

            using (FileStream stream = new FileStream(fullpath,FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filename;
        }
    }
}
