using FinanceTrackingApp.Models;
using System.Data.Common;
using System.Data;
using FinanceTrackingApp.DAL;

namespace FinanceTrackingApp.Logic
{
    public class CategoryDataAccess
    {
        public List<CategoryModel> GetCategoryNames(Guid userGuid)
        {
            //query string
            string SQL = $"Select * From categories where userGuid = \'{userGuid}\' AND categoryIsActive != 0";

            //create data objects for DB results logic
            List<CategoryModel> Output = new List<CategoryModel>();
            DataTable DBResults = new DBConnection().GetDataTable(SQL);

            for (int i = 0; i < DBResults.Rows.Count; i++)
            {
                Output.Add(new CategoryModel()
                {
                    categoryGuid = (Guid)DBResults.Rows[i]["categoryGuid"],
                    categorySortOrder = int.Parse(DBResults.Rows[i]["categorySortOrder"].ToString()),
                    categoryName = DBResults.Rows[i]["categoryName"].ToString(),
                    categoryIsActive = int.Parse(DBResults.Rows[i]["categoryIsActive"].ToString())
                });
            }
            return Output;
        }

        public CategoryModel AddUpdate(CategoryModel model, Guid userGuid)
        {
            string SQL = "";
            //If trying to make new category, then run the code in the if
            if (model.categoryGuid == Guid.Empty)
            {
                //Run insert by creating new guid here and rest of sql query
                model.categoryGuid = Guid.NewGuid();
                SQL = "INSERT INTO categories (categoryGuid, userGuid, categorySortOrder, categoryName, categoryIsActive) Values (";
                SQL += $"\"{model.categoryGuid}\", ";
                SQL += $"\"{userGuid}\", ";
                SQL += $"{model.categorySortOrder}, ";
                SQL += $"\"{model.categoryName}\", ";
                SQL += $"{model.categoryIsActive})";
                new DBConnection().ExecuteMySQL(SQL);
            }
            //If trying to update category, then run the code in the else
            else
            {
                //Run update
                SQL = "UPDATE categories SET ";
                SQL += $"categorySortOrder = {model.categorySortOrder}, ";
                SQL += $"categoryName =\"{model.categoryName}\", ";
                SQL += $" categoryIsActive = {model.categoryIsActive} ";
                SQL += $"WHERE categoryGuid = \"{model.categoryGuid}\" ";
                SQL += $"AND userGuid = \"{userGuid}\"";
                new DBConnection().ExecuteMySQL(SQL);
            }

            return model;
        }

        //unsure whether or not to use this function or the toggleCategory function below, the one below handles both setting cat to active and 'deleted' (hidden)
        public CategoryModel DeleteCategory(CategoryModel model, Guid userGuid)
        {
            string SQL = "";
            if (model.categoryGuid != Guid.Empty && userGuid != Guid.Empty)
            {
                SQL = "UPDATE categories SET ";
                SQL += $" categoryIsActive = {0}";
                SQL += $"WHERE categoryGuid = \"{model.categoryGuid}\" ";
                SQL += $"AND userGuid = \"{userGuid}\"";
                new DBConnection().ExecuteMySQL(SQL);
            }
            //not sure if i need to pass whole model or just parts of it
            return model;
        }

        public CategoryModel ToggleCategory(CategoryModel model, Guid userGuid, bool activeBool)
        {
            string SQL = "";
            //activeBool determines if user wants to activate or 'delete' category, if false, they want to 'delete' it, if true, reactivate it
            if (model.categoryGuid != Guid.Empty && userGuid != Guid.Empty)
            {
                SQL = "UPDATE categories SET ";
                SQL += $"categoryIsActive = {(activeBool == false ? 0 : 1)} "; //zero for not active, 1 for active
                SQL += $"WHERE categoryGuid = \"{model.categoryGuid}\" ";
                SQL += $"AND userGuid = \"{userGuid}\"";
                new DBConnection().ExecuteMySQL(SQL);
            }
            //not sure if i need to pass whole model or just parts of it
            return model;
        }
    }
}

