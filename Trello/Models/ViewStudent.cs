using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DAL.BusinessModels;

namespace Trello.Models
{
    public class ViewStudent
    {
        public int StudentId { set; get; }

        [Required]
        [MinLength(5)]
        public string StudentName { set; get; }

    }
}