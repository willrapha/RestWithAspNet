﻿using System.Collections.Generic;
using RestWithAspNetSwagger.Model.Base;

namespace RestWithAspNetSwagger.Repository.Generic
{
    // where T : BaseEntity - onde T precisa ser um BaseEntity
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exist(long? id);
    }
}