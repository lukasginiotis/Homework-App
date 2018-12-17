using Microsoft.EntityFrameworkCore;

namespace MyApplication.Models
{
    public class AnswersContext : DbContext
    {
        public AnswersContext(DbContextOptions<AnswersContext> options)
            : base(options)
        {
        }

        public DbSet<Answers> Answers { get; set; }
    }
}
