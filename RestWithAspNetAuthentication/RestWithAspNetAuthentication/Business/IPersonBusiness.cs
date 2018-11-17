using System.Collections.Generic;
using RestWithAspNetAuthentication.Data.VO;

namespace RestWithAspNetAuthentication.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}