using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trello.Models;
using Trello.Filters;

namespace Trello.Controllers
{
    [Log]
    public class StudentController : Controller
    {
        // GET: Student
        static List<Student> studentsList = new List<Student>{
            new Student() { StudentId = 1, StudentName = "mahdi"} ,
            new Student() { StudentId = 2, StudentName = "ahmad"} ,
            new Student() { StudentId = 3, StudentName = "abdullah"} ,
        };
        public ActionResult Index()
        {
            return View(studentsList);
        }

        public ActionResult Edit(int? Id)
        {
            Student selectedStudent;
            if (Id != null)
            {
                if (Id != 0)
                {
                    selectedStudent = studentsList.Where(s => s.StudentId == Id).FirstOrDefault();
                }
                else
                {
                    studentsList.Add(new Student { StudentId = Id.Value, StudentName = "khaled" });
                    selectedStudent = studentsList.Where(s => s.StudentId == Id).FirstOrDefault();

                }
            }
            else
            {
                selectedStudent = new Student { StudentId = 9, StudentName = "idris" };
            }
            return View(selectedStudent);
        }
        [HttpPost]
        public ActionResult Edit(Student Student)
        {
            if (ModelState.IsValid)
            {
                if(studentsList.Where(s=>s.StudentName == Student.StudentName).FirstOrDefault() != null)
                {
                    ModelState.AddModelError(string.Empty, "Student Name already exists.");
                    return View();
                }
                else
                {
                    //change to Dal
                    studentsList.Where(s => s.StudentId == Student.StudentId).FirstOrDefault().StudentName = Student.StudentName;
                }
            }
            return View("Index",studentsList);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(string StudentName)
        {
            if (ModelState.IsValid)
            {
                if (studentsList.Where(s => s.StudentName == StudentName).FirstOrDefault() != null)
                {
                    ModelState.AddModelError(string.Empty, "Student Name already exists.");
                    return View();
                }
                else
                {
                    //change to Dal
                    Student newStudent = new Student { StudentName = StudentName, StudentId = (studentsList.Count + 1) };
                    studentsList.Add(newStudent);
                }
            }
            return View("Index", studentsList);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Student selectedStudent = studentsList.Where(s => s.StudentId == Id).FirstOrDefault();
            return View(selectedStudent);
        }
        [HttpPost]
        public ActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                //change to Dal
                studentsList.Remove(studentsList.Single(s => s.StudentId == Id.Value));
            }
            return View();
        }
    }
}