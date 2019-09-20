using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.BusinessModels;


namespace DAL
{
    public class StudentDal
    {
        private static List<Student> studentsList = new List<Student>{
            new Student() { StudentId = 1, StudentName = "mahdi"} ,
            new Student() { StudentId = 2, StudentName = "ahmad"} ,
            new Student() { StudentId = 3, StudentName = "a1bdullah"} ,
            new Student() { StudentId = 4, StudentName = "ab2dullah"} ,
            new Student() { StudentId = 5, StudentName = "abd3ullah"} ,
            new Student() { StudentId = 6, StudentName = "abdu4llah"} ,
            new Student() { StudentId = 7, StudentName = "abdul5lah"} ,
            new Student() { StudentId = 8, StudentName = "abdull6ah"} ,
            new Student() { StudentId = 9, StudentName = "abdulla7h"} ,
            new Student() { StudentId = 10, StudentName = "abdulla8h"} ,
            new Student() { StudentId = 11, StudentName = "abdullah9"} ,
            new Student() { StudentId = 12, StudentName = "abdullah10"} ,
        };

        public Student Add(string StudentName)
        {
            var maxID = studentsList.Max(x => x.StudentId);
            Student newStudent = new Student { StudentName = StudentName, StudentId = maxID + 1 };
            studentsList.Add(newStudent);
            return newStudent;
        }

        public Student Edit(Student Student)
        {
            studentsList.Where(s => s.StudentId == Student.StudentId).FirstOrDefault().StudentName = Student.StudentName;
            return Student;
        }

        public Student Delete(int Id)
        {
            var std = studentsList.Single(s => s.StudentId == Id);
            studentsList.Remove(std);
            return std;
        }

        public PagedList<Student> GetAll(int page = 1, int pageSize = 10)
        {
            PagedList<Student> model = new PagedList<Student>();
            PagingModel pagingModel = new PagingModel();
            int skipedStudents = (page-1) * pageSize;
            int studentsCount = studentsList.Count;

            pagingModel.Page = page;
            pagingModel.PageSize = pageSize;
            pagingModel.PagesCount = studentsCount / pageSize;
            if (studentsCount % pageSize > 0)
            {
                pagingModel.PagesCount = pagingModel.PagesCount + 1;
            }
            pagingModel.HasNextPage = page < pagingModel.PagesCount;
            pagingModel.HasPreviousPage = page > 1;
            model.Paging = pagingModel;
            model.TableList = studentsList.Skip(skipedStudents).Take(pageSize).ToList();
            return model;
        }

        public Student GetById(int Id)
        {
            return studentsList.Where(s => s.StudentId == Id).FirstOrDefault();
        }
    }
}
