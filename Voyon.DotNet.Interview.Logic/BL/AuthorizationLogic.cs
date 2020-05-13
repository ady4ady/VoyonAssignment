using Voyon.DotNet.Interview.Core.Models;
using Voyon.DotNet.Interview.Core.Repositories;
using Voyon.DotNet.Interview.Logic.Models;
using System;
using System.Linq;
using System.Web;

namespace Voyon.DotNet.Interview.Logic.BL
{
    public class AuthorizationLogic : IAuthorizationLogic
    {
        private const string COOKIE_NAME = "CurrentUser";

        private readonly IUserRepository _usersRepository;

        public AuthorizationLogic(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public LoginButtonViewModel GetLoginButton()
        {
            string username;
            if(!TryGetCurrentUserName(out username))
            {
                return new LoginButtonViewModel
                {
                    ButtonLabel = "Login",
                    IsLoggedIn = false
                };
            }

            return new LoginButtonViewModel
            {
                ButtonLabel = "Logout",
                IsLoggedIn = true,
                CurrentUserName = username
            };
        }

        public bool TryLogin(LoginViewModel loginViewModel)
        {
            if (loginViewModel == null)
                return false;

            if (loginViewModel.Username == null || loginViewModel.Password == null)
                return false;

            var matchingUsers = _usersRepository.Get(u => u.Username.Equals(loginViewModel.Username) &&
                u.Password.Equals(loginViewModel.Password));

            if (matchingUsers == null || matchingUsers.Count() != 1)
                return false;

            CreateCookie(matchingUsers.FirstOrDefault().Id.ToString());
            return true;
        }

        public bool TryLogout()
        {
            RemoveCookie();
            return true;
        }

        private void CreateCookie(string userid)
        {
            HttpCookie currentUserCookie = new HttpCookie(COOKIE_NAME);
            currentUserCookie.Value = userid;
            currentUserCookie.Expires = DateTime.Now.AddDays(1d);

            HttpContext.Current.Response.Cookies.Remove(COOKIE_NAME);
            HttpContext.Current.Response.Cookies.Add(currentUserCookie);
        }

        private void RemoveCookie()
        {
            if (HttpContext.Current.Request.Cookies[COOKIE_NAME] != null)
            {
                HttpCookie myCookie = new HttpCookie(COOKIE_NAME);
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(myCookie);
                HttpContext.Current.Session.Abandon();
            }
        }

        private bool TryGetCurrentUserName(out string username)
        {
            username = null;

            HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies.Get(COOKIE_NAME);
            if (currentUserCookie == null)
                return false;
            
            Guid userGuid;
            if (!Guid.TryParse(currentUserCookie.Value, out userGuid))
                return false;

            User user = _usersRepository.Get(userGuid);
            if (user == null)
                return false;

            username = user.Username;
            return true;
        }
    }
}
