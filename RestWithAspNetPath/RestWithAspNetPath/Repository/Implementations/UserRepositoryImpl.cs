using System.Linq;
using RestWithAspNetPath.Model;
using RestWithAspNetPath.Model.Context;

namespace RestWithAspNetPath.Repository.Implementations
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