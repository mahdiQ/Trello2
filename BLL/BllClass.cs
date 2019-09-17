using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.BusinessModels;

namespace BLL
{
    public class BllClass
    {
        public static DalClass dalClass = new DalClass();
        static List<Student> studentList = dalClass.GetAllStudent();
        public List<Student> AddStudent(string StudentName)
        {
            List<Student> newList = dalClass.AddStudent(StudentName);
            return (newList);
        }

        public List<Student> EditStudent(Student UpdatedStudent)
        {
            List<Student> newList = new List<Student>();
            newList = dalClass.EditStudent(UpdatedStudent);
            return (newList);
        }

        public void DeleteStudent(int Id)
        {
            dalClass.DeleteStudent(Id);
        }

        public List<Student> GetAllStudent()
        {
            return (dalClass.GetAllStudent());
        }

        public Student GetStudentById(int Id)
        {
            return (dalClass.GetStudentById(Id));
        }
    }
}
