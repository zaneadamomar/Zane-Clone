using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HelpingHandsWebApp.Models;

namespace HelpingHandsWebApp.Models
{
    public class HelpingHandsWebApp_ContextSeeder:CreateDatabaseIfNotExists<HelpingHandsWebApp_Context>
    {
        protected override void Seed(HelpingHandsWebApp_Context context)
        {

            Account admin = new Account
            {
                Username = "Admin",
                Password = "Admin",
                Category = "Admin",
                email = "helpinghandsorg69@gmail.com"
            };
            context.Accounts.Add(admin);
            context.SaveChanges();
        }
    }
}