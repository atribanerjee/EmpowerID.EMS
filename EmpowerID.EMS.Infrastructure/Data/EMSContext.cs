using EmpowerID.EMS.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpowerID.EMS.Infrastructure.Data
{
    public partial class EMSContext : DbContext
    {
        public EMSContext() { }

        public EMSContext(DbContextOptions<EMSContext> options) : base(options) { }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}
