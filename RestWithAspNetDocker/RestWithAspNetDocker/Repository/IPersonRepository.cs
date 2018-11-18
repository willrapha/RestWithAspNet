using System.Collections.Generic;
using RestWithAspNetDocker.Model;
using RestWithAspNetDocker.Repository.Generic;

namespace RestWithAspNetDocker.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}