using FileUploader.Models;

namespace FileUploader.Controllers.Helpers
{
    public class MediaFilesHelper
    {
        public MediaFilesHelper() { }
        public CatalogueData GetCurrentFiles()
        {
            var result = new CatalogueData();
            var path = Path.Combine("wwwroot", "media");
            var dir=new DirectoryInfo(path);
            foreach (var file in dir.EnumerateFiles())
            {
                if (file.Extension.ToLower()==".mp4")
                {
                    result.Videos.Add(new FileMetaData { FileName = file.Name, FileSize = file.Length });
                }
            }
            if (result.Videos.Count>0)
            {
                result.SelectedFile=result.Videos[0];
            }
            return result;
        }
    }
}
