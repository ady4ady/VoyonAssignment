using Voyon.DotNet.Interview.Logic.Models;

namespace Voyon.DotNet.Interview.Logic.BL
{
    public interface IAuthorizationLogic
    {
        bool TryLogin(LoginViewModel loginViewModel);
        bool TryLogout();
        LoginButtonViewModel GetLoginButton();
    }
}
