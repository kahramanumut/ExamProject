using ExamProject.BusinessLayer;
using ExamProject.Entities;
using ExamProject.WebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.WebApp.Controllers
{
    [_SessionControl]
    public class ExamController : Controller
    {
        QuestionAnswerViewModels model = new QuestionAnswerViewModels();
        List<Question> questionList = new List<Question>();
        public ActionResult Index()
        {
            ExamManager get = new ExamManager();
            Question queModel = new Question();

            queModel = get.RandomExam();
            return View(queModel);
        }

        public JsonResult CheckAnswer(string QueIdAndAnswer, int questionID)
        {
            ExamManager check = new ExamManager();
            //List<TrueAnswerWithId> list = new List<TrueAnswerWithId>();
           //list = check.CheckAnswer(QueIdAndAnswer, questionID);
            return Json(JsonConvert.SerializeObject(check.CheckAnswer(QueIdAndAnswer, questionID), Formatting.Indented), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Create(int id = 0)
        {

            HtmlParse htmlParse = new HtmlParse();
            questionList = htmlParse.GetTextandTitle();
            ViewBag.quesListBag = questionList;
            ViewBag.quesText = questionList[id].QuestionText;
            ViewBag.quesTitle = questionList[id].QuestionTitle;
            ViewBag.quesId = id;

            return View(model);
        }

        [ValidateInput(false)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuestionAnswerViewModels model, string quesTitle, string quesText)
        {
            
              Question quesAdd = new Question();
                quesAdd.QuestionText = quesText;
                quesAdd.QuestionTitle = quesTitle;
            if (ModelState.IsValid)
            {
                ExamManager save = new ExamManager();
                save.ExamSave(model.QuestionAnswer, quesAdd);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create"); ;
        }

        public ActionResult Delete()
        {
            ExamManager getList = new ExamManager();
            QuestionAnswerViewModels model = new QuestionAnswerViewModels();
            model.Question = getList.ExamGet();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int ID)
        {
            ExamManager examDelete = new ExamManager();
            examDelete.ExamDelete(ID);
            
            return RedirectToAction("Index");
        }

        public string GetTextByTitleId(int id)
        {
            HtmlParse htmlParse = new HtmlParse();
            questionList = htmlParse.GetTextandTitle();
            return questionList[id].QuestionText;
        }
    }
}