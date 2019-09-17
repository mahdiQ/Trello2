using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.BusinessModels;


namespace DAL
{
    public class DalClass
    {
        static List<Student> studentsList = new List<Student>{
            new Student() { StudentId = 1, StudentName = "mahdi"} ,
            new Student() { StudentId = 2, StudentName = "ahmad"} ,
            new Student() { StudentId = 3, StudentName = "abdullah"} ,
        }; 

        public List<Student> AddStudent(string StudentName)
        {
            Student newStudent = new Student { StudentName = StudentName, StudentId = (studentsList.Count + 1) };
            studentsList.Add(newStudent);
            return (studentsList);
        }

        public List<Student> EditStudent(Student Student)
        {
            studentsList.Where(s => s.StudentId == Student.StudentId).FirstOrDefault().StudentName = Student.StudentName;
            return (studentsList);
        }

        public void DeleteStudent(int Id)
        {
            studentsList.Remove(studentsList.Single(s => s.StudentId == Id));
        }

        public List<Student> GetAllStudent()
        {
            return (studentsList);
        }

        public Student GetStudentById(int Id)
        {   
            return (studentsList.Where(s=>s.StudentId == Id).FirstOrDefault());
        }
    }
}
