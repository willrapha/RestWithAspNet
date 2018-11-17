using System.Collections.Generic;
using RestWithAspNetHateoas.Data.VO;

namespace RestWithAspNetHateoas.Business
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