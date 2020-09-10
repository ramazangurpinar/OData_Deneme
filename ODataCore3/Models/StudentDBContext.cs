using Microsoft.EntityFrameworkCore;

namespace ODataCore3.Models
{
    public class StudentDBContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer(@"Data Source=NIRVANA\SQLEXPRESS;Initial Catalog=ODataWebApiNetCore;Integrated Security=True");
        }
    }
}
