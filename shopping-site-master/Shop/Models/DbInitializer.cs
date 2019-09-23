using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Items.Any())
            {
                context.AddRange
                    (
                        new Item {  Name = "Iphone", ShortDescription = "A nice phone", Price = 8.500, IsItemOfTheWeek = false },
                        new Item { Name = "Car", ShortDescription = "A nice car", Price = 50.000, IsItemOfTheWeek = false },
                        new Item {  Name = "House", ShortDescription = "A nice house", Price = 150.000, IsItemOfTheWeek = false },
                        new Item {  Name = "Tshirt", ShortDescription = "A nice tshirt", Price = 10, IsItemOfTheWeek = true }
                    );
                context.SaveChanges();
            }
        }
    }
}
