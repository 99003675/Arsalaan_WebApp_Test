using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1_Scrum2.Data;
using WebApplication1_Scrum2.Models;

namespace WebApplication1_Scrum2.Controllers
{
    public class ProductController : Controller
    {
        private readonly MVCDemoDBContext mvcDemoDBContext;
        static int c = 0;

        public ProductController(MVCDemoDBContext mvcDemoDBContext)
        {
            this.mvcDemoDBContext = mvcDemoDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await mvcDemoDBContext.product.ToListAsync();
            return View(products);

        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            var prod = new AddProductViewModel()
            {
                Id = c+1,
                Title = model.Title,
                price = model.price,
                stock = model.stock

            };
            await mvcDemoDBContext.product.AddAsync(prod);
            await mvcDemoDBContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        /*[HttpGet]

        public async  Task<IActionResult> View(int id)
        {

            var product = await mvcDemoDBContext.product.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                var ViewModel = new Update()
                {
                    Id = product.Id,
                    Title = product.Title,
                    price = product.price,
                    stock = product.stock

                };

                return await Task.Run(()=> View(ViewModel));
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public  async Task<IActionResult> View(Update update)
        {
            var product = await mvcDemoDBContext.product.FindAsync(update.Id);
            if(product != null)
            {
                product.Title = update.Title;
                product.price = update.price;
                product.stock = update.stock;
                product.image = update.image;

                await mvcDemoDBContext.SaveChangesAsync();
                return RedirectToAction("Index");


            }
            return RedirectToAction("Index");
        }*/
    } 
}
