using RestWithAspNetDockers.Data.VO;

namespace RestWithAspNetDockers.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}