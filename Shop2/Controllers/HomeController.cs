using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop2.Models;
using Shop2.Models.Image;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop2.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext db;
        AppDbContext _context;


        public HomeController(AppDbContext context)
        {
            _context = context;
            db = context;
            context.Products.AddRange(
                    //new Product { ProductName = "Iphone 13 Pro Max", Price = 150000, Descriptons = "dfdfdf", Quantitys = 1 }
                    //new Product { ProductName = "Iphone 13 Pro", Price = 130000, Descriptons = "dfdfdf", Quantitys = 1, Images = "dsdsd" },
                    //new Product { ProductName = "Iphone 13", Price = 100000, Descriptons = "dfdfdf", Quantitys = 1, Images = "dsdsd" },
                    //new Product { ProductName = "Iphone 12 Pro Max", Price = 120000, Descriptons = "dfdfdf", Quantitys = 1, Images = "dsdsd" },
                    //new Product { ProductName = "Iphone 12 Pro", Price = 100000, Descriptons = "dfdfdf", Quantitys = 1, Images = "dsdsd" },
                    //new Product { ProductName = "Iphone 12", Price = 90000, Descriptons = "dfdfdf", Quantitys = 1, Images = "dsdsd" },
                    //new Product { ProductName = "Iphone 11 Pro Max", Price = 100000, Descriptons = "dfdfdf", Quantitys = 1, Images = "dsdsd" }

                    );
            context.SaveChanges();

        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 3;
            IQueryable<Product> source = db.Products;
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items
            };
            return View(viewModel);

        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product, ImageViewModel pvm)
        {
            if (pvm.ImageProduct != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.ImageProduct.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.ImageProduct.Length);
                }

                // установка массива байтов
                product.ImageProduct = imageData;
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
