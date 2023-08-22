using demopopway.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demopopway.Controllers
{
    
    public class ExamController : Controller
    {
        demoappEntities3 ExamDb = new demoappEntities3();
        // GET: Exam
        public ActionResult scoreinfo(Exam__Score exob)
        {
            return View(exob);
        }

        [HttpPost]
        public ActionResult AddScore(Exam__Score model)
        {
             
            Exam__Score exsobj = new Exam__Score();
            //if (ModelState.IsValid)
            //{
                exsobj.id = model.id;
                exsobj.subject = model.subject;
                exsobj.score = model.score;
                exsobj.student_id = model.student_id; 

            

                if (model.id == 0)
                {
                    
                ExamDb.Exam__Score.Add(exsobj); 
                ExamDb.SaveChanges();

                }
                else
                {
                    ExamDb.Entry(exsobj).State = EntityState.Modified;
                    ExamDb.SaveChanges();
                }


            //}
            ModelState.Clear();
            return View("scoreinfo");
        }

        [HttpGet]
        public ActionResult GetScore(Exam__Score model)
        {
            using(demoappEntities3 db =new demoappEntities3())
            {
                var res = db.Exam__Score.Include("Student").ToList();
                return View(res);
            }
            
        }
        public ActionResult delete(int id)
        {
            var res = ExamDb.Exam__Score.Where(x => x.id == id).First();
            ExamDb.Exam__Score.Remove(res);
            ExamDb.SaveChanges();

            var list = ExamDb.Exam__Score.ToList();
            return View("GetScore", list);
        }
    }
}