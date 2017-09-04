using Insala.Domain.Abstract;
using Insala.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Insala.WebUI.Controllers
{
    public class AuthenticationController : Controller
    {
        IAuthenticationProvider _authenticationprovider;


        public AuthenticationController(IAuthenticationProvider authenticationprovider)
        {
            this._authenticationprovider = authenticationprovider;
        }

        public ActionResult Index()
        {
            LoginViewModel viewModel = new LoginViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel, String ReturnUrl)
        {
            if (ModelState.IsValid) 
            {
                string msgErro = String.Empty;
                var user = this._authenticationprovider.Login(viewModel.Email, viewModel.Password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Email, false);
                    System.Web.HttpContext.Current.Session["AuthenticUser"] = user;

                    return Redirect(ReturnUrl ?? Url.Action("Index", "Home"));
                }
                else {
                    TempData["Message"] = "authentication failure";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.Remove("UsuarioAutenticado");
            return RedirectToAction("Index");
        }

    }
}
