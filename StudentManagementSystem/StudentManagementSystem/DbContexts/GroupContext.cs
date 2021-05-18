using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;


namespace StudentManagementSystem.DbContexts
{
    public sealed class GroupContext : DbContext
    {
        public GroupContext(DbContextOptions<GroupContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //entities
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}