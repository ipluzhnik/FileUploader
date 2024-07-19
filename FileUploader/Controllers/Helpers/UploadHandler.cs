namespace FileUploader.Controllers.Helpers
{
    public class UploadHandler
    {
        public UploadHandler() { }
        public string Upload(IFormFileCollection fileCollection)
        {
            var validExtensions = new List<string>() { ".mp4" };

            foreach (var file in fileCollection)
            {
                //extension
                var ext = Path.GetExtension(file.FileName);
                if (!validExtensions.Contains(ext.ToLower()))
                    return $"File {file.FileName} has invalid extension";
                //file size
                var size = file.Length;
                if (size > 200 * 1024 * 1024)
                    return $"File {file.FileName} has has exceeded 200MB limit";
                var path = Path.Combine("wwwroot", "media", file.FileName);
                //save file to media folder
                using var fs = new FileStream(path, FileMode.Create);
                file.CopyTo(fs);
            }
            return string.Empty;
        }
    }
}
