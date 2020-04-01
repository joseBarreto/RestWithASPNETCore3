using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Model.Base;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly MySqlContext _context;
        private readonly DbSet<T> dataSet;

        public GenericRepository(MySqlContext context)
        {
            _context = context;
            dataSet = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                dataSet.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }

        public void Delete(long id)
        {
            try
            {
                if (Exist(id))
                {
                    var result = FindById(id);
                    dataSet.Remove(result);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Exist(long? id)
        {
            return dataSet.Any(p => p.Id.Equals(id));
        }

        public IList<T> FindAll()
        {
            return dataSet.ToList();
        }

        public T FindById(long? id)
        {
            return dataSet.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Update(T item)
        {
            try
            {
                if (Exist(item.Id))
                {
                    var result = FindById(item.Id);
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }
    }
}
