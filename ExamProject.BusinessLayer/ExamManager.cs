using ExamProject.DAL;
using ExamProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExamProject.BusinessLayer
{
    public class ExamManager
    {
        ExamDbContext db = new ExamDbContext();
        QuestionAnswer questionAnswerObject = new QuestionAnswer();
        Question questionObject = new Question();
        
        //Başlık, yazı, soruların ve cevaplarının DB'ye kayıt edilmesi..
        public void ExamSave(List<QuestionAnswer> questionAnswer, Question question)
        {
            //HtmlDecode --> Wired.com 'dan gelen html datada özel karakterlerin DB'ye aktarırken bozuk gözükmesini engellemek için
                questionObject= new Question { Questions = questionAnswer , QuestionText = HttpUtility.HtmlDecode(question.QuestionText), QuestionTitle = HttpUtility.HtmlDecode(question.QuestionTitle) , CreatedTime=DateTime.Now };
                db.Question.Add(questionObject);
                db.SaveChanges();
        }

        public List<Question> ExamGet()
        {
           return  db.Question.ToList();
        }

        //ID ile gelen Soruyu ve o soruya ait alt soruları silinmesi
        public void ExamDelete(int id)
        {
            
            questionObject = db.Question.Where(x=>x.ID == id).SingleOrDefault();

            for (int i = questionObject.Questions.Count-1; i >= 0; i--)
            {
                db.QuestionAnswer.Remove(questionObject.Questions[i]);
            }

            db.SaveChanges();

            db.Question.Remove(questionObject);
            db.SaveChanges();
        }

        //Kullanıcıya rasgele bir soru sorulması
        public Question RandomExam()
        {
            //Tüm ID'ler bir diziye atıldı
            int [] idList = db.Question.Select(x => x.ID).ToArray();
            //Random bir sayı üretildi.
            Random rnd = new Random();
            int rndNumber = rnd.Next(0,idList.Length);
            int id = idList[rndNumber];
            return db.Question.Where(x=>x.ID==id).FirstOrDefault();
        }
       
        //Quiz tarafında kullanıcıya sorulan soru ve verdiği cevaplar alındı
        //questionID = Sorunun başlığı ve textinin bulunduğu veriye ait olan ID
        //QueIdAndAnswer örnek: 00,11,22,30 , ilk karakter soru , ikinci karakter verilen cevap
        public List<TrueAnswerWithId> CheckAnswer(string QueIdAndAnswer , int questionID)
        {
            // Doğru cevabı , sorunun ID'sini ve sorunun doğru olup olmadığını geri dönmek için liste
            List<TrueAnswerWithId> queAnsBool = new List<TrueAnswerWithId>();
            // Soruya ait alt 4 sorunun getirilmesi
            questionObject = db.Question.Where(x => x.ID == questionID).FirstOrDefault();

            //QueIdAndAnswer 'ın virgül yardımı ile bir string dizisine atadık
            char split = ',';
            string[] arrayAnswer = QueIdAndAnswer.Split(split);

            // Her verilen cevabı sorunun id'si yardımı ile doğru cevabını karşılaştırdık ve queAnsBool listesine ekledik
            for (int i = 0; i < arrayAnswer.Length; i++)
            {
                TrueAnswerWithId trueAnswer = new TrueAnswerWithId();
                int queID = Int16.Parse(arrayAnswer[i][0].ToString());
                int ansID = Int16.Parse(arrayAnswer[i][1].ToString());

                trueAnswer.QuestionId = queID;

                if (questionObject.Questions[queID].TrueAnswer == ansID)
                    trueAnswer.IsTrue = true;
                else
                    trueAnswer.IsTrue = false;

                trueAnswer.TrueAnswer = questionObject.Questions[i].TrueAnswer;

                queAnsBool.Add(trueAnswer);
            } 
            return queAnsBool;
        }
    }
}
