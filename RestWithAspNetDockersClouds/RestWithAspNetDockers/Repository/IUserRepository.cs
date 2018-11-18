using RestWithAspNetDockers.Model;

namespace RestWithAspNetDockers.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}