﻿using System.Collections.Generic;
using RestWithAspNetGenerictDataContract.Data.VO;

namespace RestWithAspNetGenerictDataContract.Business
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