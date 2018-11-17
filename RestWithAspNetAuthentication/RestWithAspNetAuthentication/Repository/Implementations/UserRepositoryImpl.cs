using System.Linq;
using RestWithAspNetAuthentication.Model;
using RestWithAspNetAuthentication.Model.Context;

namespace RestWithAspNetAuthentication.Repository.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySqlContext _context;

        public UserRepositoryImpl(MySqlContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}