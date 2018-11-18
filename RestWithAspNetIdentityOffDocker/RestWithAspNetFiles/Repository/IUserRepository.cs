using RestWithAspNetFiles.Model;

namespace RestWithAspNetFiles.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}