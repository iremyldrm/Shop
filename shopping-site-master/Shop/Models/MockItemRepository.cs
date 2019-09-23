using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class MockItemRepository : IItemRepository
    {
        private List<Item> _items;

        public MockItemRepository(){

            if(_items == null)
            {
                InitializeItems();
            }

        }

        public void InitializeItems()
        {
            _items = new List<Item>
            {
                new Item {Id = 1, Name = "Iphone", ShortDescription ="A nice phone", Price = 8.500, IsItemOfTheWeek = false},
                new Item {Id = 2, Name = "Car", ShortDescription = "A nice car", Price =50.000, IsItemOfTheWeek = false },
                new Item {Id = 3, Name = "House", ShortDescription = "A nice house", Price = 150.000, IsItemOfTheWeek = false },
                new Item {Id =4, Name = "Tshirt", ShortDescription = "A nice tshirt", Price=10, IsItemOfTheWeek=true}
            };

        }


        public IEnumerable<Item> GetAllItems()
        {
            return _items;
        }

        public Item GetItemById(int itemId)
        {
            return _items.FirstOrDefault(p => p.Id == itemId);
        }

        public Item Add(Item newItem)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Item Update(Item updatedItem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
