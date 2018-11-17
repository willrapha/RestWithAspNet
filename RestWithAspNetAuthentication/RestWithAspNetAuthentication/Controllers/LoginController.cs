using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNetAuthentication.Business;
using RestWithAspNetAuthentication.Data.VO;

namespace RestWithAspNetAuthentication.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
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