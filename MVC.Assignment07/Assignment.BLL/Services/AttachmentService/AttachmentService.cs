using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Assignment.BLL.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        List<string> AllowedExtensions = [".png",".jpg",".jpeg"];
        //maxsize = 2 megabytes
        //megabyte = 1024 kilobyte
        //kilobyte = 1024 bytes
        const int _maxSize = 2_097_152;

        public string? Upload(IFormFile file, string folderName)
        {
            //1.Check Extension
            var extension = Path.GetExtension(file.FileName);
            if (!AllowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase))
                return null;

            //2.Check Size
            if (file.Length == 0 || file.Length > _maxSize)
                return null;

            //3.Get Located Folder Path
            //var folderPath = "D:\\Route\\MVC.Assignment07\\Assignment.PL\\wwwroot\\Files\\Images\\";
            //or 
            //var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files\\Images\\";
            //or
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Files", "Images");

            //4.Make Attachment Name Unique-- GUID
            var fileName = $"{Guid.NewGuid()}_{file.FileName}";

            //5.Get File Path
            var filePath = Path.Combine(folderPath, fileName);

            //6.Create File Stream To Copy File[Unmanaged]
            using FileStream fs = new FileStream(filePath, FileMode.Create);

            //7.Use Stream To Copy File
            file.CopyTo(fs);

            //8.Return FileName To Store In Database
            return fileName;
        }

        public bool Delete(string filePath)
        {
           if(!File.Exists(filePath))
                return false;

           File.Delete(filePath);

           return true;
        }

    }
}
