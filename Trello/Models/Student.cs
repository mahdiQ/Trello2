using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trello.Models
{
    public class Student
    {
        public Student()
        {
            Active = true;
        }

        public int StudentId { set; get; }

        [Required]
        [MinLength(5)]
        public string fName { set; get; }

        [MinLength(5)]
        public string MName { set; get; }

        [MinLength(5)]
        public string LName { set; get; }

        public DateTime DOB { set; get; }

        public Gender Gender { set; get; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public int? CreatedBy { get; set; }

        public ContentInfo ContentInfo { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

}