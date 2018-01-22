using ExamProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.BusinessLayer
{
    public class Test
    {
        public Test()
        {
            ExamDbContext deneme = new ExamDbContext();
            deneme.Question.ToList();
        }
    }
}
