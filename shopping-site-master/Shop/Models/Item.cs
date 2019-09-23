using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public bool IsItemOfTheWeek { get; set; }
        public string ImgPath { get; set; }

        public void setImgPath(string path)
        {
            ImgPath = path;
        }
    }
}
