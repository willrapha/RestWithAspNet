using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RestWithAspNetAuthentication.Model.Base;
using RestWithAspNetAuthentication.Model.Context;

namespace RestWithAspNetAuthentication.Repository.Generic
{
    // A implementação do repositório genérico
    // Recebe qualquer Tipo T que implemente IRepository de mesmo tipo
    // Desde que T extenda BaseEntity
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MySqlContext _context;
        private readonly DbSet<T> _dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public T FindById(long id)
        {
            return _dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _dataSet.ToList();
        }

        public T Update(T item)
        {
            // Verificamos se a pessoa existe na base
            // Se não existir retornamos vazio
            if (!Exist(item.Id)) return null;

            // Pega o estado atual do registro no banco
            // seta as alterações e salva
            var result = _dataSet.SingleOrDefault(p => p.Id.Equals(item.Id));

            try
            {
                // Atualiza apenas os campos diferentes do estado atual do registro no banco
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

            return item;
        }

        public void Delete(long id)
        {
            var item = _dataSet.FirstOrDefault(p => p.Id.Equals(id));
            try
            {
                if (item != null) _dataSet.Remove(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Exist(long? id)
        {
            //Busca se existe
            return _dataSet.Any(p => p.Id.Equals(id));
        }
    }
}