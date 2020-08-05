using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
    /// <summary>
    /// Repository for Sub category table 
    /// </summary>
    public class SubCategoryRepository : IRepository<SubCategory>, IDisposable
    {
        private ItemsStoreContext _context;
        public SubCategoryRepository(ItemsStoreContext context)
        {
            _context = context;
        }
        public void Add(SubCategory entity)
        {
            _context.SubCategory.Add(entity);
        }

        public IEnumerable<SubCategory> GetAll()
        {
            return _context.SubCategory.ToList();
        }

        public SubCategory GetById(int id)
        {
            return _context.SubCategory
                       .SingleOrDefault(b => b.Id == id);
        }

        public SubCategory GetByName(string name)
        {
            return _context.SubCategory
                       .SingleOrDefault(b => b.Name == name);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
