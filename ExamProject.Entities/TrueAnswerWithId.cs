using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Entities
{
    public class TrueAnswerWithId
    {
        public int QuestionId { get; set; }
        public bool IsTrue { get; set; }
        public int TrueAnswer { get; set; }
    }
}
