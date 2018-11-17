using System.Collections.Generic;
using RestWithAspNetPath.Data.VO;

namespace RestWithAspNetPath.Business
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