using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetDocker.Business;
using RestWithAspNetDocker.Data.VO;

namespace RestWithAspNetDocker.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class LoginController : Controller
    {
        private readonly ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        // [AllowAnonymous]  - pessoas nao authenticadas na aplicação vou poder acessar no minimo o login
        [AllowAnonymous] 
        [HttpPost]
        public object Post([FromBody]UserVO user)
        {
            if (user == null) return BadRequest();

            return _loginBusiness.FindByLogin(user);
        }

    }
}