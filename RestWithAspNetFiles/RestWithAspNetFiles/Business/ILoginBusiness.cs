using RestWithAspNetFiles.Data.VO;

namespace RestWithAspNetFiles.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}