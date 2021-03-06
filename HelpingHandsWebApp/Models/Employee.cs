﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace HelpingHandsWebApp.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [Display(Name = "Organisation ID")]
        public int empID { get; set; }

        [Display(Name = "Organisation Name")]
        public string empName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int cell { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        public string Address { get; set; }
    }
}
