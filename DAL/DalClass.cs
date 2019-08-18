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

        public void Add(string StudentName)
        {
            Student newStudent = new Student { StudentName = StudentName, StudentId = (studentsList.Count + 1) };
            studentsList.Add(newStudent);
        }

        public void Edit(Student Student)
        {
            studentsList.Where(s => s.StudentId == Student.StudentId).FirstOrDefault().StudentName = Student.StudentName;
        }

        public void Delete(int Id)
        {
            studentsList.Remove(studentsList.Single(s => s.StudentId == Id));
        }

        public List<Student> GetAll()
        {
            return (studentsList);
        }

        public Student GetById(int Id)
        {   
            return (studentsList.Where(s=>s.StudentId == Id).FirstOrDefault());
        }
    }
}
