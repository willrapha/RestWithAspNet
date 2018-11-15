using System.Collections.Generic;
using RestWithAspNetGenerictValueObject.Data.VO;
using RestWithAspNetGenerictValueObject.Model;

namespace RestWithAspNetGenerictValueObject.Business
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