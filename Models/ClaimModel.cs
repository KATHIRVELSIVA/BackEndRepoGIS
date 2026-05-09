using System.ComponentModel.DataAnnotations;

namespace CrudMicroProject.Models
{
    public class ClaimModel
    {
        [Key]
        public int ClaimID { get; set; }
        public string? ClaimName { get; set; }
        public string? ClaimReason { get; set; }
        public string? FIRNo { get; set; }
        public string? Status { get; set; }
        public int ApplyId { get; set; }
    }
}
