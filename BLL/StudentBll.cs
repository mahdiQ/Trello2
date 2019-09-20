using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.BusinessModels;

namespace BLL
{
    public class StudentBll
    {
        public static StudentDal dalClass = new StudentDal();
        //static List<Student> studentList = dalClass.GetAll();
        public Student Add(string StudentName)
        {
            Student newStudent = dalClass.Add(StudentName);
            return (newStudent);
        }

        public Student Edit(Student UpdatedStudent)
        {
            Student newStudent = new Student();
            newStudent = dalClass.Edit(UpdatedStudent);
            return (newStudent);
        }

        public Student Delete(int Id)
        {
            var std = dalClass.Delete(Id);
            return std;
        }

        public PagedList<Student> GetAll(int page = 1, int pageSize = 10)
        {
            return (dalClass.GetAll(page , pageSize));
        }

        public Student GetById(int Id)
        {
            return (dalClass.GetById(Id));
        }
    }
}
