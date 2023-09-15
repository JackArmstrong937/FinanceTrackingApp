using FinanceTrackingApp.Logic;
using Microsoft.AspNetCore.Mvc;
using FinanceTrackingApp.Models;

namespace FinanceTrackingApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //[HttpGet]
        //[Route("index")]
        //public IActionResult Index()
        //{
        //    List<CategoryModel> model = new CategoryDataAccess().GetCategoryNames(Guid.NewGuid());
        //    return View(model);
        //}

        [HttpPost]
        [Route("index")]
        public IActionResult Index(List<CategoryModel> model)
        {
            foreach (CategoryModel cat in model)
            {
                //if (cat.categoryGuid = Guid.Empty)
                //{
                //    CategoryModel newItem = new CategoryModel() { categoryGuid = Guid.NewGuid(), categoryName = cat.categoryName, categoryIsActive = 1 };
                //    new CategoryDataAccess().Save(newItem);
                //}
                //else
                //{
                //    CategoryModel update = new CategoryDataAccess().GetCategory(cat.categoryGuid);
                //    update.categoryName = cat.categoryName;
                //    new CategoryDataAccess().Save(update);
                //}
            }

            model = new CategoryDataAccess().GetCategoryNames(Guid.NewGuid());
            return View(model);
        }
    }
}
