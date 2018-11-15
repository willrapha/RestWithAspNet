using System.Collections.Generic;
using RestWithAspNetGenerictValueObject.Data.Converters;
using RestWithAspNetGenerictValueObject.Data.VO;
using RestWithAspNetGenerictValueObject.Model;
using RestWithAspNetGenerictValueObject.Repository.Generic;

namespace RestWithAspNetGenerictValueObject.Business.Implementations
{
    public class BookBusinessImpl : IBookBusiness
    {
        private readonly IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusinessImpl(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public BookVO Create(BookVO book)
        {
            //Regras de negocio

            var bookEntity = _converter.Parse(book);
            _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public BookVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public List<BookVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public BookVO Update(BookVO book)
        {
            var bookEntity = _converter.Parse(book);
            _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}