using RestWithAspNetQueryParams.Model;

namespace RestWithAspNetQueryParams.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}