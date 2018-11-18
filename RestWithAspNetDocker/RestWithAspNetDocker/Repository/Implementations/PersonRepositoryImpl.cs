﻿using System.Collections.Generic;
using System.Linq;
using RestWithAspNetDocker.Model;
using RestWithAspNetDocker.Model.Context;
using RestWithAspNetDocker.Repository.Generic;

namespace RestWithAspNetDocker.Repository.Implementations
{
    public class PersonRepositoryImpl : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepositoryImpl(MySqlContext context) 
            : base(context)
        {
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            else
            {
                return _context.Persons.ToList();
            }
        }
    }
}