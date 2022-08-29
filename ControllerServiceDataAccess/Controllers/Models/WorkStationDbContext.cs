using Microsoft.EntityFrameworkCore;


namespace ControllerServiceDataAccess.Models
{
    public class WorkStationDbContext : DbContext
    {
        public WorkStationDbContext(DbContextOptions<WorkStationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<SysUser> SysUser { get; set; }

        public virtual DbSet<Student> Student { get; set; }

    }
}
