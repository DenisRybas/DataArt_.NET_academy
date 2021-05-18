using Microsoft.EntityFrameworkCore;
using Student_groups;
using Group = Student_groups.Group;

namespace Student_groups_crud
{
    public class GroupContext : DbContext
    {
        public GroupContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=RYBAS_D\MYSQLSERVER;Database=PhysFacGroups;Trusted_Connection=True;");
        }

        //entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}