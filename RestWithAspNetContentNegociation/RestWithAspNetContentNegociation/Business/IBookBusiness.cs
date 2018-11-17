using System.Collections.Generic;
using RestWithAspNetContentNegociation.Data.VO;

namespace RestWithAspNetContentNegociation.Business
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