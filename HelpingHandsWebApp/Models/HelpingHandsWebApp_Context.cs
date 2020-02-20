using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HelpingHandsWebApp.Models
{
    public class HelpingHandsWebApp_Context : DbContext
    {
        public HelpingHandsWebApp_Context() : base("name=HelpingHandsWebApp_Context")
        {
            Database.SetInitializer(new HelpingHandsWebApp_ContextSeeder());
        }

        public System.Data.Entity.DbSet<HelpingHandsWebApp.Models.Account> Accounts { get; set; }
        public System.Data.Entity.DbSet<HelpingHandsWebApp.Models.OrgDetails> OrgDetails { get; set; }
        public System.Data.Entity.DbSet<HelpingHandsWebApp.Models.DonorDetails> DonorDetails { get; set; }
        public System.Data.Entity.DbSet<HelpingHandsWebApp.Models.Courier> Couriers { get; set; }
        public System.Data.Entity.DbSet<HelpingHandsWebApp.Models.Delivery> Deliveries { get; set; }
        public System.Data.Entity.DbSet<HelpingHandsWebApp.Models.Hamper> Hampers { get; set; }

    }
}