using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FacultyOfPhysics.Model;

namespace FacultyOfPhysics.DAL
{
    class GroupContext : DbContext
    {
        public GroupContext()
            : base("DBFacultyOfPhysics")
        { }

        public DbSet<Group> Group { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
