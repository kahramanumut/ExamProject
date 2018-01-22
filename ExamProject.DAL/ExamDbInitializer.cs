using ExamProject.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.DAL
{
    public class ExamDbInitializer : CreateDatabaseIfNotExists<ExamDbContext>
    {
        // DB yoksa oluşturulup, örnek datanın insert edilmesi 
        protected override void Seed(ExamDbContext context)
        {
            Question question = new Question();
            List<QuestionAnswer> list = new List<QuestionAnswer>();

            User deneme = new User()
            {
                Name = "Umut",
                Surname = "Kahraman",
                Username = "umut",
                Password = "123123"
            };
            context.User.Add(deneme);


            // Başlık ve Paragraf oluşturarak bunların içindede 4'er soru ve cevaplarıyla eklendi.
            // Fakedata kütüphanesi ile örnek data oluşturuldu.
            for (int i = 0; i < 4; i++)
                {
                    QuestionAnswer questionAnswer = new QuestionAnswer();
                    questionAnswer.Question = FakeData.TextData.GetSentence();
                    questionAnswer.FirstAnswer = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(3, 50));
                    questionAnswer.SecondAnswer = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(3, 50));
                    questionAnswer.ThirdAnswer = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(3, 50));
                    questionAnswer.FourthAnswer = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(3, 50));
                    questionAnswer.TrueAnswer = FakeData.NumberData.GetNumber(0,4);
                    context.QuestionAnswer.Add(questionAnswer);
                }
                context.SaveChanges();

                list = context.QuestionAnswer.ToList();

                question.Questions = list;
                question.QuestionText = FakeData.TextData.GetSentences(3);
                question.QuestionTitle = FakeData.TextData.GetSentence();
                question.CreatedTime = FakeData.DateTimeData.GetDatetime().Date;
                context.Question.Add(question);

            context.SaveChanges();
        }
    }
}
