using RestWithAspNetDocker.Data.VO;

namespace RestWithAspNetDocker.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}