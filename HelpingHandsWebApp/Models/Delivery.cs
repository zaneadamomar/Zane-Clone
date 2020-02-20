using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HelpingHandsWebApp.Models
{
    public class Delivery
    {
        [Key]
        public int deliveryID { get; set; }

        public int courierID { get; set; }
        public Courier courier { get; set; }

        public int hamperID  { get; set; }
        public Packages hamper { get; set; }

        public string destination { get; set; }
    }
}