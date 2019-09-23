using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int itemId);
        Item Add(Item newItem);
        Item Update(Item updatedItem);
        void Delete(int id);
        int Commit();

    }
}
