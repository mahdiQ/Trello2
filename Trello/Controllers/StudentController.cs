using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Trello.Models;
using Trello.Filters;
using BLL;
using DAL;
using DAL.BusinessModels;

namespace Trello.Controllers
{
    [Log]
    public class StudentController : Controller
    {
        // GET: Student
        static BllClass bllClass = new BllClass();
        static List<Student> studentList = bllClass.GetAllStudent();
        public ActionResult Index()
        {
            return View(studentList);
        }

        public ActionResult Save(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return View("Create");
            }
            else
            {
                Student selectedStudent;
                selectedStudent = bllClass.GetStudentById(Id.Value);
                selectedStudent.CurrentName = selectedStudent.StudentName; 
                return View("Edit", selectedStudent);
            }

        }

        [HttpPost]
        public ActionResult Save(Student Student)
        {
            if (ModelState.IsValid)
            {
                if (Student.StudentName != Student.CurrentName && studentList.Where(s => s.StudentName == Student.StudentName).FirstOrDefault() != null)
                {
                    ModelState.AddModelError(string.Empty, "Student Name already exists.");
                    return View("Edit");
                }
                else
                {
                    if (Student.StudentId == 0)
                    {
                        studentList = bllClass.AddStudent(Student.StudentName);
                    }
                    else
                    {
                        studentList = bllClass.EditStudent(Student);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Student selectedStudent = studentList.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(selectedStudent);
        }
        [HttpPost]
        public ActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                bllClass.DeleteStudent(Id.Value);
            }
            return RedirectToAction("Index");
        }
    }
}