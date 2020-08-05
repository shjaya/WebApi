using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApiProject.Repository
{
    /// <summary>
    /// This interface will use to define all the repository methods.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// 
    public interface IRepository<TEntity>
    {
        TEntity GetByName(string name);
        TEntity GetById(int id);
        void Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Save();
    }
}
