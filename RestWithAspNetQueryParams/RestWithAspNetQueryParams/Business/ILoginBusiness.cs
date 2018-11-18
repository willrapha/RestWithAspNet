using RestWithAspNetQueryParams.Data.VO;

namespace RestWithAspNetQueryParams.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}