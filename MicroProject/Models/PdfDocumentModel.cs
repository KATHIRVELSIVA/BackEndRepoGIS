using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMicroProject.Models
{
    public class PdfDocumentModel
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] FIelData { get; set; }
        public DateTime UploadDate { get; set; }
         public int UserID { get; set; }

    }
}
