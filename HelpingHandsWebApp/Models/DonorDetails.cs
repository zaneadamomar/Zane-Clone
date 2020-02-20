using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelpingHandsWebApp.Models
{
    [Table("DonorDetails")]
    public class DonorDetails
    {
        [Key]
        [Display(Name = "Donor ID")]
        public int donorID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }
    }
}