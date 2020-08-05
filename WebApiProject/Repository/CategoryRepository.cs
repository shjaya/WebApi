using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
    /// <summary>
    /// Repository for Category
    /// </summary>
    public class CategoryRepository : IRepository<Category>, IDisposable
    {
        private ItemsStoreContext _context;
        public CategoryRepository(ItemsStoreContext context)
        {
            _context = context;
        }
        public Category GetByName(string name)
        {
            return _context.Category
                       .SingleOrDefault(b => b.Name == name);
        }

        public void Add(Category entity)
        {
            _context.Category.Add(entity);
        }

        public Category GetById(int id)
        {
            return _context.Category
                        .SingleOrDefault(b => b.Id == id);
        }
        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
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
