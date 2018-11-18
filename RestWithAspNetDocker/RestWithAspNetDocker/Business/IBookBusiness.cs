using System.Collections.Generic;
using RestWithAspNetDocker.Data.VO;

namespace RestWithAspNetDocker.Business
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