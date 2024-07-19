namespace FileUploader.Models
{
    public class CatalogueData
    {
        public List<FileMetaData> Videos { get; set; }=new List<FileMetaData>();
        public FileMetaData? SelectedFile {  get; set; }
    }
}
