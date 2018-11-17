using System.Collections.Generic;
using RestWithAspNetContentNegociation.Data.Converters;
using RestWithAspNetContentNegociation.Data.VO;
using RestWithAspNetContentNegociation.Model;
using RestWithAspNetContentNegociation.Repository.Generic;

namespace RestWithAspNetContentNegociation.Business.Implementations
{
    // Camada para tratar regras de negocio
    public class PersonBusinessImpl : IPersonBusiness
    {
        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImpl(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            //Regras de negocio

            var personEntity = _converter.Parse(person);
            _repository.Create(personEntity);

            return _converter.Parse(personEntity);
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}