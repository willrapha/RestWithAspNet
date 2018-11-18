using System.Collections.Generic;
using RestWithAspNetQueryParams.Model;
using RestWithAspNetQueryParams.Repository.Generic;

namespace RestWithAspNetQueryParams.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}