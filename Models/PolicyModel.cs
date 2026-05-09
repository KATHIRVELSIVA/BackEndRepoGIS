using System.ComponentModel.DataAnnotations;

namespace CrudMicroProject.Models
{
    public class PolicyModel
    {
        [Key]
        public int PolicyID { get; set; }
        public string? PolicyName { get; set; }
        public string? PolicyDescription { get; set; }
        public float PolicyPrice { get; set; }
        public bool? PolicyStatus { get; set; }

    }
}
