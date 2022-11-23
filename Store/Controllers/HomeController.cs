using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Models;
using Store.Models.Entities;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDbContext baza;

        public HomeController(AppDbContext dbContext)
        {
            baza = dbContext;
            //baza.Marks.Add(new Models.Entities.Mark { Name = "FLO" });
            //baza.Marks.Add(new Models.Entities.Mark { Name = "Ulker" });



            //for (int i = 0; i < baza.Marks.ToList().Count; i++)
            //{
            //    baza.Marks.Remove(baza.Marks.ToList()[i]);

            //}
            baza.SaveChanges();
        }

        [HttpGet]
        public IActionResult AddMark()
        {

            return View();
        }
        public IActionResult AddProduct()
        {
            baza.Marks.Include("Products");
            List<SelectListItem> marks = new();
            foreach (var mark in baza.Marks)
            {
                marks.Add(new SelectListItem() { Text = mark.Name, Value = mark.Id.ToString() });
            }
            ViewData["marks"] = marks;
            return View();

        }
        public IActionResult AllMarks()
        {
        
            return View(baza.Marks.ToList());
        }
        public IActionResult AllProducts()
        {

            return View(baza.Products.ToList());
        }

        public IActionResult DeleteMark()
        {
            return View(baza.Marks.ToList());
        }

        public IActionResult Menu()
        {
            return View();
        }
        [HttpPost, ActionName("AddMark")]
        public IActionResult AddMark(Mark mark)
        {
            if (mark.Name != null )
            {
                baza.Marks.Add(new Mark { Name=mark.Name});
                baza.SaveChanges();

            }
            return RedirectToAction("AddMark");
        }
        [HttpPost, ActionName("AddProduct")]
        public IActionResult AddProduct(Product product)
        {
            if (product.Name != null)
            {
   

                Product lazim =new Product();
                lazim.Name=product.Name;
            
                baza.Products.Add(lazim);
                
             
                lazim.mark_id = product.mark_id;
                lazim.Mark= baza.Marks.FirstOrDefault(x => x.Id == lazim.mark_id);
                baza.SaveChanges();
                baza.Update(baza.Products.FirstOrDefault(d => d.Name == lazim.Name));
                baza.SaveChanges();

            }
            return RedirectToAction("AllProducts");
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteMark(int number)
        {
            if (number - 1 >= 0 && number - 1 < baza.Marks. Count())
            {


                baza.Marks.Remove(baza.Marks.ToList()[number-1]);
                baza.SaveChanges();

            }
            return RedirectToAction("AllMarks");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}