using demopopway.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demopopway.Controllers
{
    public class StudentController : Controller
    {
        demoappEntities3 StudentDb = new demoappEntities3();
        
        // GET: Student
        public ActionResult StudentInfo(Student stob)

        {
            
                return View(stob);
             
        }

        [HttpPost]
        public ActionResult AddStudent(Student model)
        {
            Student stobj = new Student();
            if (ModelState.IsValid)
            {
                stobj.ID = model.ID;
                stobj.Student_Name = model.Student_Name;
                stobj.Student_Age = model.Student_Age;
                stobj.Contact_Number = model.Contact_Number;
                stobj.Address = model.Address;
                if(model.ID ==0)
                {
                    StudentDb.Students.Add(stobj);
                    StudentDb.SaveChanges();

                }
                else
                {
                    StudentDb.Entry(stobj).State = EntityState.Modified;
                    StudentDb.SaveChanges();
                }

               
            }
            ModelState.Clear();
            return View("StudentInfo");
        }

        [HttpGet]
        public ActionResult GetStudent(Student model)
        {
            var res = StudentDb.Students.ToList();
            return View(res);
        }
        public ActionResult delete(int id)
        {
            var res = StudentDb.Students.Where(x => x.ID == id).First();
            StudentDb.Students.Remove(res);
            StudentDb.SaveChanges();

            var list = StudentDb.Students.ToList();
            return View("GetStudent",list);
        }


        
    }
}