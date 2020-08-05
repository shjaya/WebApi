using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Repository
{
    /// <summary>
    /// Repository for Item model
    /// </summary>
    public class ItemRepository : IRepository<Item>, IDisposable
    {
        private ItemsStoreContext _context;
        public ItemRepository(ItemsStoreContext context)
        {
            _context = context;
        }
        public void Add(Item entity)
        {
            _context.Item.Add(entity);
        }

        public Item GetById(int id)
        {
            return _context.Item
                        .SingleOrDefault(b => b.Id == id);
        }

        public Item GetByName(string name)
        {
            return _context.Item
                       .SingleOrDefault(b => b.Name == name);
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Item.ToList();
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
