using System.Collections.Generic;
using RestWithAspNetGenerictValueObject.Model;

namespace RestWithAspNetGenerictValueObject.Business
{
    public interface IBookBusiness
    {
        Book Create(Book person);
        Book FindById(long id);
        List<Book> FindAll();
        Book Update(Book person);
        void Delete(long id);
    }
}