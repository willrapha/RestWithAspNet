using System;
using System.Collections.Generic;
using System.Linq;
using RestWithAspNetLayers.Model;
using RestWithAspNetLayers.Model.Context;
using RestWithAspNetLayers.Services.Implementations;

namespace RestWithAspNetLayers.Services
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
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person Update(Person person)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos uma instancia vazia de pessoa
            if (!Exist(person.Id)) return new Person();

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                // Atualiza apenas os campos diferentes do estado atual do registro no banco
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return person;
        }

        public void Delete(long id)
        {
            var person = _context.Persons.FirstOrDefault(p => p.Id.Equals(id));
            try
            {
                if(person != null) _context.Persons.Remove(person);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool Exist(long? id)
        {
            //Busca se existe
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}