using System.Collections.Generic;
using RestWithAspNetFiles.Model;
using RestWithAspNetFiles.Repository.Generic;

namespace RestWithAspNetFiles.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}