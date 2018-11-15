using System.Collections.Generic;
using RestWithAspNetGenerictValueObject.Data.VO;

namespace RestWithAspNetGenerictValueObject.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO person);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO person);
        void Delete(long id);
    }
}