using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new(){Id=1,Name="Ferhat",Surname="Ersoy",Age=24},
                new() {Id=2,Name="Betül",Surname="Ersöz",Age=12 }

            } );
        }
    }
}