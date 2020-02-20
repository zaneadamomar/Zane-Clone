using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpingHandsWebApp.Models
{
    public class Packages
    {
        [Key]
        public int packageID { get; set; }
        public int donorID { get; set; }
        public DonorDetails donor { get; set; }

        public string packageDetails { get; set; }


    }
}