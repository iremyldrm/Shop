using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shop.Controllers
{
    public class ImageController : Controller
    {
       
        private readonly IItemRepository itemRepo;

        public Item item;



        public IActionResult OnGet(int id)
        {
            var item = itemRepo.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        private readonly IHostingEnvironment _appEnvironment;
        public ImageController(IHostingEnvironment appEnvironment, IItemRepository itemRepository)
        {
            _appEnvironment = appEnvironment;
            itemRepo = itemRepository;
        }



        [HttpGet] //1.Load
        public IActionResult UploadImg( int id)
        {
            var item = itemRepo.GetItemById(id);
            return View();
        }

        [HttpPost] //Postback
        public async Task<IActionResult> UploadImg(IFormFile file, int id)
        {
            var item = itemRepo.GetItemById(id);
            if (file == null || file.Length == 0) return Content("file not selected");
            string path_Root = _appEnvironment.WebRootPath;
            string path_to_Images = "wwwroot\\images\\user_images\\" + file.FileName;
            using (var stream = new FileStream(path_to_Images, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            ViewData["FilePath"] = path_to_Images;
            string showPath = "/images/user_images/" + file.FileName;
            item.setImgPath(showPath);
            itemRepo.Commit();
            return View();
        }
    }
}

    