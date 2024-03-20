using Microsoft.EntityFrameworkCore;
using MVP.Models;

namespace Answer_The_Questions.Data
{
    public class DataContext : DbContext
    {
        //public DataContext()
        //{
            
        //}

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<WrongAnswer> WrongAnswers { get; set; }
        public DbSet<RightAnswer> RightAnswers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> AllAnswers { get; set; }
    }
}
