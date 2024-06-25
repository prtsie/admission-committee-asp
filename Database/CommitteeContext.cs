using System.Data.Entity;
using Database.Models;

namespace Database
{
    public sealed class CommitteeContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; } = null!;
    }
}
