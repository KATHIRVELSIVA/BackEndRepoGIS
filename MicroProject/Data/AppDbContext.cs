using Microsoft.EntityFrameworkCore;
using CrudMicroProject.Models;

namespace CrudMicroProject.Data
{
    public class AppDbContext : DbContext
    {
        internal object Appointment;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<AdminModel> Admin { get; set; }
        public DbSet<UserModel> User { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
        public DbSet<PolicyModel> Policy { get; set; }
        public DbSet<AddOnPolicyModel> AddOnPolicy { get; set; }
        public DbSet<InsuranceApplyModel> InsuranceApply { get; set; }
        public DbSet<ClaimModel> Claim { get; set; }
        public DbSet<ClaimAmountModel> ClaimAmounts { get; set; }
        public DbSet<PdfDocumentModel> PdfDocument { get; set; } = default!;
    }
}
