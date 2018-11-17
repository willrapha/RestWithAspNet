using RestWithAspNetPath.Data.VO;

namespace RestWithAspNetPath.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}