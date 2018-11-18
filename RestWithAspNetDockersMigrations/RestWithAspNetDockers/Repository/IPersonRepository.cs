using System.Collections.Generic;
using RestWithAspNetDockers.Model;
using RestWithAspNetDockers.Repository.Generic;

namespace RestWithAspNetDockers.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}