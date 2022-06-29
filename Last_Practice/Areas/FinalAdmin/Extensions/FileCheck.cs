using Microsoft.AspNetCore.Http;

namespace Last_Practice.Areas.FinalAdmin.Extensions
{
    public static class FileCheck
    {
        public static bool IsFile(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsGreates(this IFormFile file,int mb)
        {
            return file.Length < mb * 1024 * 1024;
        }

        public static bool IsOkay(this IFormFile file,int mb)
        {
            return IsFile(file) && IsGreates(file,mb);
        }
    }
}
