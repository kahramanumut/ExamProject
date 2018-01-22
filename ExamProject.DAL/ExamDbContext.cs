using ExamProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.DAL
{
    public class ExamDbContext:DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }

        public ExamDbContext()
        {
            Database.SetInitializer(new ExamDbInitializer());
        }
    }
}
