using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelpingHandsWebApp.Models
{
    [Table("Courier")]
    public class Courier
    {
        [Key]
        public int courierID { get; set; }

        public string courierName { get; set; }

        public string courierSurname { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Cell { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}