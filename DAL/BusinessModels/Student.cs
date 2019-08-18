using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.BusinessModels
{
    public class Student
    {
        public int StudentId { set; get; }
        [Required]
        [MinLength(5)]
        public string StudentName { set; get; }
    }
}
