using System.Collections.Generic;
using System.Linq;
using RestWithAspNetGenerictDataContract.Data.Converter;
using RestWithAspNetGenerictDataContract.Data.VO;
using RestWithAspNetGenerictDataContract.Model;

namespace RestWithAspNetGenerictDataContract.Data.Converters
{
    public class PersonConverter : IParser<Person, PersonVO>, IParser<PersonVO, Person>
    {
        // Person to PersonVO
        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new PersonVO();

            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        // PersonList to PersonVOList
        public List<PersonVO> ParseList(List<Person> origin)
        {
            if (origin == null) return new List<PersonVO>();

            // Internamente é como se o Linq executasse um foreach convertendo cada item da lista
            return origin.Select(item => Parse(item)).ToList();
        }

        // PersonVO to Person
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();

            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        // PersonVOList to PersonList
        public List<Person> ParseList(List<PersonVO> origin)
        {
            if (origin == null) return new List<Person>();

            // Internamente é como se o Linq executasse um foreach convertendo cada item da lista
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}