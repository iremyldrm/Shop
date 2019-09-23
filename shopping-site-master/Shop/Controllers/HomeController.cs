using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using Shop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;
        private readonly AppDbContext context;
        public static string imgPath;

        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var items = _itemRepository.GetAllItems().OrderBy(p => p.Name);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Title = "Items overview";
            homeViewModel.Items = items.ToList();
            
            

            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var item = _itemRepository.GetItemById(id);
            if(item == null)
            {
                return NotFound();
            }
            return View(item);
        }


        public IActionResult AddNewItem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewItem(Item item)
        {
            item.ImgPath = imgPath;
            _itemRepository.Add(item);
            _itemRepository.Commit();
            return RedirectToAction("Details", new { id = item.Id });
        }
        
        public IActionResult DeleteItem(int id)
        {
            var item = _itemRepository.GetItemById(id);
            _itemRepository.Delete(id);
            _itemRepository.Commit();
            return RedirectToAction("Index");
        }

    }
}
