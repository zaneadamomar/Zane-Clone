using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelpingHandsWebApp.Models;
using System.Security.Claims;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using HelpingHandsWebApp.ViewModels;

namespace HelpingHandsWebApp.Controllers
{
    public class AccountsController : Controller
    {
        private HelpingHandsWebApp_Context db = new HelpingHandsWebApp_Context();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "AccID,Username,Password,ConfirmPassword,email,Category")] Account account)
        {
            string accid = account.Username;
            string accpass = account.Password;
            TempData["Username"] = accid;

            if (ModelState.IsValid)
            {
                db.Accounts.Add(account);
                db.SaveChanges();

                TempData["Username"] = accid;
                LoginViewModel log = new LoginViewModel();
                log.Username = accid;
                log.Password = accpass;
                regLogin(log);

                // Account.BuildEmailTemplate("Iqsaanmia@gmail.com","registered");

                return Content("Success");
            }

            return View(account);
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////
        /// 

        //Log In
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Unauthorised", "Unauthorised");
            }
            return View();
        }

        // Log in 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //if (ModelState.IsValid)
            // {
            try
            {
                var accID = (from c in db.Accounts
                             where c.Username == model.Username
                             where c.Password == model.Password
                             select c.AccID).FirstOrDefault();
                int accountID = Convert.ToInt16(accID);

                var loginInfo = (from c in db.Accounts
                                 where c.Username == model.Username
                                 where c.Password == model.Password
                                 select new { c.Username, c.Password }).ToList();

                var accType = (from c in db.Accounts
                               where c.AccID == accountID
                               select c.Category).Single();

                //var positionID = db.Employees.Where(u => u.AccountID == accID).Select(u => u.PositionID).Count();

                if (accType == "Donor" || accType == "donor")
                {
                    var role = "Donor";
                    var Dlogindetails = loginInfo.First();

                    SignInUser(Dlogindetails.Username, role, false);

                    return RedirectToLocal(returnUrl);

                }

                else if (accType == "Admin" || accType == "admin")
                {
                    var logindetails = loginInfo.First();
                    string addrole = "Admin";

                    SignInUser(logindetails.Username, addrole, false);
                    if (returnUrl == null)
                    {
                        return RedirectToAction("AdminPage", "Home");
                    }
                    else
                    {
                        return RedirectToLocal(returnUrl);
                    }
                }
                 else if (accType == "Organisation" || accType == "organisation")
                {
                    var role = "Organisation";
                    var Dlogindetails = loginInfo.First();

                    SignInUser(Dlogindetails.Username, role, false);

                    return RedirectToLocal(returnUrl);

                }

                else if(accType == "Courier" || accType == "courier")
                {
                    var role = "Courier";
                    var Dlogindetails = loginInfo.First();

                    SignInUser(Dlogindetails.Username, role, false);

                    return RedirectToLocal(returnUrl);

                }            
    
                else if (loginInfo.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Incorrect Username or Password");
                    //ViewBag.LoginError = "Incorrect Username or Password";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    //return View(model);
                }
            }
            catch
            {
                //ViewBag.errorLogin = ex.ToString();
                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }
            return View(model);
        }

        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccID,Username,Password,email,Category")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



       
        [AllowAnonymous]
        public ActionResult regLogin(LoginViewModel model)
        {
            var loginInfo = (from c in db.Accounts
                             where c.Username == model.Username
                             where c.Password == model.Password
                             select new { c.Username, c.Password }).ToList();
            var accType = (from c in db.Accounts
                           where c.Username == model.Username
                           where c.Password == model.Password
                           select c.Category).Single();

            if (accType == "Admin" || accType == "admin")
            {
                var Role = "Admin";
                var Custlogindetails = loginInfo.First();

                SignInUser(Custlogindetails.Username, Role, false);
                //return this.RedirectToLocal(returnUrl);
            }
            else if (accType == "Donor" || accType == "donor")
            {
                var Role = "Donor";
                var Custlogindetails = loginInfo.First();

                SignInUser(Custlogindetails.Username, Role, false);
                //return this.RedirectToLocal(returnUrl);
            }
            else if (accType == "Organisation" || accType == "organisation")
            {
                var Role = "Organisation";
                var Custlogindetails = loginInfo.First();

                SignInUser(Custlogindetails.Username, Role, false);
                //return this.RedirectToLocal(returnUrl);
            }
            return View(model);
        }
        private void SignInUser(string username, string Role, bool isPersistent)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Name, username));
                claims.Add(new Claim(ClaimTypes.Role, Role));
                var claimIds = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            try
            {
                if (Request.IsAuthenticated)
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return Content("Access Denied");
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return View();
        }

    }
}
