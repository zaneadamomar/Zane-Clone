using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Web;

namespace HelpingHandsWebApp.Models
{
    [Table("OrgDetails")]
    public class OrgDetails
    {
        [Key]
        [Display(Name = "Organisation ID")]
        public int orgID { get; set; }

        [Display(Name = "Organisation Name")]
        public string orgName { get; set; }

        [Display(Name = "Organisation Image")]
        public byte[] orgImage { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string email { get; set; }

        public string Address { get; set; }
    }
}
