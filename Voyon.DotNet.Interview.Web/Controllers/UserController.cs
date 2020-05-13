using Voyon.DotNet.Interview.Logic.BL;
using Voyon.DotNet.Interview.Logic.Models;
using System.Web.Mvc;

namespace Voyon.DotNet.Interview.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IAuthorizationLogic _authorizationLogic;

        public UserController(IAuthorizationLogic authorizationLogic)
        {
            _authorizationLogic = authorizationLogic;
        }
        
        public ActionResult LoginButton()
        {
            return PartialView(_authorizationLogic.GetLoginButton());
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if(!_authorizationLogic.TryLogin(loginViewModel))
            {
                loginViewModel.ErrorMessage = "Your credentials were wrong";
                loginViewModel.Password = null;

                return View(loginViewModel);
            }

            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _authorizationLogic.TryLogout();
            return RedirectToAction("Index", "Task");
        }
    }
}