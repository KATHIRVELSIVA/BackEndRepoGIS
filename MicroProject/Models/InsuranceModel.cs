using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CrudMicroProject.Models
{
    public class InsuranceModel
    {
        [Key]
        public int ApplyId { get; set; }
        public required UserModel UserModel { get; set; }
        public required PolicyModel PolicyModelID { get; set; }
        public required AddOnPolicyModel AddOnPolicy { get; set; }
        public int VehicleID { get; set; }
        public string? status { get; set; }
    }
}
