using System.Collections.Generic;
using RestWithAspNetAuthentication.Model;

namespace RestWithAspNetAuthentication.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}