using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;




using System.Web.Security;





namespace QuickSecureLoginExample.Filters
{






    public class XAuthorizeAttribute : AuthorizeAttribute
    {



        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {

            filterContext.Result =
                new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new { controller = "Account", action = "Login" }));

            // base.HandleUnauthorizedRequest(filterContext);
        }




        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            HttpCookie AuthCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (AuthCookie == null)
                return false;

            FormsAuthenticationTicket Auth;

            try
            {
                Auth = FormsAuthentication.Decrypt(AuthCookie.Value);
            }
            catch
            {
                return false;
            }

            if (!Auth.Expired)
                return true;
            else
                return false;


            //return base.AuthorizeCore(httpContext);
        }






    }





}