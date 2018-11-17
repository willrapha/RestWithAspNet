using RestWithAspNetPath.Model;

namespace RestWithAspNetPath.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}