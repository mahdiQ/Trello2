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

        public ActionResult Edit(int? Id)
        {
            Student selectedStudent;
            selectedStudent = bllClass.ViewEditStudent(Id);
            return View(selectedStudent);
        }
        [HttpPost]
        public ActionResult Edit(Student Student)
        {
            if (ModelState.IsValid)
            {
                if (studentList.Where(s => s.StudentName == Student.StudentName).FirstOrDefault() != null)
                {
                    ModelState.AddModelError(string.Empty, "Student Name already exists.");
                    return View();
                }
                else
                {
                    studentList = bllClass.EditStudent(Student);
                }
            }
            return View("Index", studentList);
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
                if (studentList.Where(s => s.StudentName == StudentName).FirstOrDefault() != null)
                {
                    ModelState.AddModelError(string.Empty, "Student Name already exists.");
                    return View();
                }
                else
                {
                    //change to Dal
                    studentList = bllClass.AddStudent(StudentName);
                }
            }
            return View("Index", studentList);
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
                //change to Dal
                bllClass.DeleteStudent(Id.Value);
            }
            return View();
        }
    }
}