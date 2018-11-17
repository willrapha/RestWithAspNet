using RestWithAspNetAuthentication.Data.VO;

namespace RestWithAspNetAuthentication.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}