using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using Trello.Models;
using Trello.Filters;
using Trello.Models;
using BLL;
using DAL;
using DAL.BusinessModels;

namespace Trello.Controllers
{
    [Log]
    public class StudentController : Controller
    {
        // GET: Student
        private StudentBll _StudentBLL = new StudentBll();
        public ActionResult Index()
        {
            var StudentsList = _StudentBLL.GetAll();
            return View(StudentsList);
        }
        [HttpPost]
        public ActionResult Paging(int currentPage)
        {
            var studentList = _StudentBLL.GetAll(currentPage);
            return PartialView("_StudentsList", studentList);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id != null)
            {
                var selectedStudent = _StudentBLL.GetById(Id.Value);
                return View(selectedStudent);
            }
            else
            {
                var newStd = new Student();
                return View(newStd);
            }

        }

        [HttpPost]
        public ActionResult Edit(Student Student)
        {
            if (ModelState.IsValid)
            {
                var studentList = _StudentBLL.GetAll().TableList;
                var OldStd = studentList.Exists(s => s.StudentName == Student.StudentName && s.StudentId != Student.StudentId);
                if (OldStd)
                {
                    ModelState.AddModelError(string.Empty, "Student Name already exists.");
                    return View();
                }
                else
                {
                    if (Student.StudentId == 0)
                    {
                        Student = _StudentBLL.Add(Student.StudentName);
                    }
                    else
                    {
                        _StudentBLL.Edit(Student);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var selectedStudent = _StudentBLL.GetById(Id);
            return View(selectedStudent);
        }
        [HttpPost]
        public ActionResult Delete(int? Id)
        {
            if (Id != null)
            {
                var std = _StudentBLL.Delete(Id.Value);
            }
            return RedirectToAction("Index");
        }
    }
}