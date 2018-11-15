using System.Collections.Generic;
using RestWithAspNetGenerictRepository.Model;
using RestWithAspNetGenerictRepository.Repository.Generic;

namespace RestWithAspNetGenerictRepository.Business.Implementations
{
    // Camada para tratar regras de negocio
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            //Regras de negocio

            return _repository.Create(person);
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}