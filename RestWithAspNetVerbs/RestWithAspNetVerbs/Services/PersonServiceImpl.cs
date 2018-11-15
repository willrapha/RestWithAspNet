using System.Collections.Generic;
using System.Threading;
using RestWithAspNetVerbs.Model;
using RestWithAspNetVerbs.Services.Implementations;

namespace RestWithAspNetVerbs.Services
{
    public class PersonServiceImpl : IPersonService
    {
        // Contador responsavel por gerar o Fake Id já que não estamos acessando a base de dados
        // volatile - a cada instacia do servidor é zerada a variavel
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Willian",
                LastName = "Raphael",
                Address = "Navirai 500",
                Gender = "Male"
            };
        }

        public List<Person> FindAll()
        {
            var persons = new List<Person>();

            for (var i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }

            return persons;
        }

        public Person Update(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person Last Name" + i,
                Address = "Person Adress" + i,
                Gender = "Person Gender" + i
            };
        }
         
        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}