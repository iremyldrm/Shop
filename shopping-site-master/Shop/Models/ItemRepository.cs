using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ItemRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Item Add(Item newItem)
        {
            _appDbContext.Add(newItem);
           
            return newItem;
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var item = GetItemById(id);
            if (item != null)
                _appDbContext.Items.Remove(item);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _appDbContext.Items;
        }

        public Item GetItemById(int itemId)
        {
            return _appDbContext.Items.FirstOrDefault(p => p.Id == itemId);
        }

        public Item Update(Item updatedItem)
        {
            var entity = _appDbContext.Items.Attach(updatedItem);
            entity.State = EntityState.Modified;
            return updatedItem;
        }
    }
}
