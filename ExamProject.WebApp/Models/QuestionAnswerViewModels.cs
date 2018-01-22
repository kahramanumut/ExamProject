using ExamProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.WebApp.Models
{
    public class QuestionAnswerViewModels
    {
        public List<Question> Question { get; set; }
        public List<QuestionAnswer> QuestionAnswer { get; set; }
    }
}