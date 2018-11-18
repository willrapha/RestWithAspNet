using RestWithAspNetDocker.Model;

namespace RestWithAspNetDocker.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}