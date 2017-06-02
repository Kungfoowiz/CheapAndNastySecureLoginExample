using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;





using QuickSecureLoginExample.Models; 




using System.Web.Security;

using System.Security.Cryptography;
using System.Text;






namespace QuickSecureLoginExample.Controllers
{





    public class AccountController : Controller
    {





        /// GET: /Account/Generate
        /// 
        [AllowAnonymous]
        public ContentResult Generate(string Input = "")
        {

            if (Input == "")
                return Content("No input.");

            SHA1 SHA = new SHA1CryptoServiceProvider();
            byte[] Data = SHA.ComputeHash(Encoding.UTF8.GetBytes(Input));
            StringBuilder Output = new StringBuilder();

            for (int Index = 0; Index < Data.Length; Index++)
                Output.Append(Data[Index].ToString("x2"));

            return Content(Output.ToString());

        }




        #pragma warning disable CS0618
        /// GET: /Account/Login
        /// 
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// POST: /Account/Login
        /// 
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(MyLoginModel LoginModel)
        {
            if (ModelState.IsValid)
            {
                var Authenticated = FormsAuthentication.Authenticate(
                    LoginModel.User, LoginModel.Pass);

                if (Authenticated)
                {
                    FormsAuthentication.SetAuthCookie(LoginModel.User, true);
                    FormsAuthentication.RedirectFromLoginPage(LoginModel.User, true);
                    // return RedirectToAction("Index", "Secure");
                }
            }


            ModelState.AddModelError("", "Please try again");
            return View(LoginModel);

        }






    }




}



