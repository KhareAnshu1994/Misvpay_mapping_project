using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Mapping_Solution.CustomHelper
{
    public class FileUploadHelper
    {

        public static List<Uploder>Upload(HttpPostedFileBase UploadFile)
        {
            List<Uploder> Files = new List<Uploder>();
            try
            {
                if (UploadFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(UploadFile.FileName);
                    string FolderPath = Path.Combine(HttpContext.Current.Server.MapPath("~/UploadFile"), fileName);
                    UploadFile.SaveAs(FolderPath);
                    Uploder newUpload = new Uploder();
                    newUpload.FilePath = FolderPath.Replace("~", "");
                    Files.Add(newUpload);
                }
            }
            catch (Exception)
            {
                throw;   
            }
            return Files;
        }

        public class Uploder
        {
            public string FilePath { get; set; }
        }
    }
}