using FinanceTrackingApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using FinanceTrackingApp.Logic;

namespace FinanceTrackingApp.Controllers
{
    public class CategoryDataController : Controller
    {
        [Route("CategoryData")]
        [EnableCors("default")]
        public class ClientDataController : Controller
        {
            //Action for returning all categories of respective user
            [Route("GetCategories")]
            [HttpGet]
            public JsonResult GetCategoryNames(Guid userGuid)
            {
                return Json(new CategoryDataAccess().GetCategoryNames(userGuid));
            }

            //Action for adding or updating categories
            [Route("Add_Update")]
            [HttpPost]
            public JsonResult AddUpdate(CategoryModel model, Guid userGuid)
            {
                return Json(new CategoryDataAccess().AddUpdate(model, userGuid));
            }

            //may not need this method, could potentially use the one below for handling both activating and 'deleting' categories
            [Route("Delete")]
            [HttpPost]
            public JsonResult DeleteCategory(CategoryModel model, Guid userGuid)
            {
                return Json(new CategoryDataAccess().DeleteCategory(model, userGuid));
            }

            //not sure whether or not to use this method instead of delete action (trying to figure out how to toggle hidding categories)
            [Route("Active_Toggle")]
            [HttpPost]
            public JsonResult ToggleCategory(CategoryModel model, Guid userGuid, bool activeBool)
            {
                return Json(new CategoryDataAccess().ToggleCategory(model, userGuid, activeBool));
            }
        }
    }
}
