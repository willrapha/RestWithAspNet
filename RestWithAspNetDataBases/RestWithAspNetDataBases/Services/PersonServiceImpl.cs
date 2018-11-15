using System;
using System.Collections.Generic;
using System.Threading;
using RestWithAspNetDataBases.Model;
using RestWithAspNetDataBases.Model.Context;
using RestWithAspNetDataBases.Services.Implementations;

namespace RestWithAspNetDataBases.Services
{
    public class PersonServiceImpl : IPersonService
    {

        private MySqlContext _context;

        public PersonServiceImpl(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

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
                Id = 1,
                FirstName = "Person Name" + i,
                LastName = "Person Last Name" + i,
                Address = "Person Adress" + i,
                Gender = "Person Gender" + i
            };
        }
    }
}