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
        public void Add(string StudentName)
        {
            dalClass.Add(StudentName);
        }

        public void Edit(Student Student)
        {
            dalClass.Edit(Student);
        }

        public void Delete(int Id)
        {
            dalClass.Delete(Id);
        }

        public List<Student> GetAll()
        {
            return (dalClass.GetAll());
        }

        public Student GetById(int Id)
        {
            return (dalClass.GetById(Id));
        }
    }
}
