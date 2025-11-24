using Microsoft.EntityFrameworkCore;
using Second_API_project.Model;

namespace Second_API_project.Dbcontext
{
    public class App_context:DbContext

    {
        public App_context(DbContextOptions<App_context>options):base(options) 
        {
            
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
