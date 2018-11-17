using System.Collections.Generic;
using RestWithAspNetAuthentication.Data.VO;

namespace RestWithAspNetAuthentication.Business
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