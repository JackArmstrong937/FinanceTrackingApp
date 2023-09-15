using FinanceTrackingApp.Models;
using System.Data.Common;
using System.Data;
using FinanceTrackingApp.DAL;

namespace FinanceTrackingApp.Logic
{
    public class TransactionDataAccess
    {
        public List<TransactionModel> GetTransactionHistory(Guid userGuid)
        {
            //query string
            string SQL = $"Select * From transactions where userGuid = \'{userGuid}\' AND transIsVisible != 0";

            //create data objects for DB results logic
            List<TransactionModel> Output = new List<TransactionModel>();
            DataTable DBResults = new DBConnection().GetDataTable(SQL);

            for (int i = 0; i < DBResults.Rows.Count; i++)
            {
                Output.Add(new TransactionModel()
                {
                    transactionGuid = (Guid)DBResults.Rows[i]["transactionGuid"],
                    userGuid = (Guid)DBResults.Rows[i]["userGuid"],
                    transDate = (DateTime)DBResults.Rows[i]["transDate"],
                    transPayedTo = DBResults.Rows[i]["transPayedTo"].ToString(),
                    transNote = DBResults.Rows[i]["transNote"].ToString(),
                    transCategoryGuid = (Guid)DBResults.Rows[i]["transCategory"],
                    transAmount = (float)DBResults.Rows[i]["transPayedAmount"],
                });
            }
            return Output;
        }

        public TransactionModel AddUpdate(TransactionModel model, Guid userGuid)
        {
            string SQL = "";
            //If trying to make new transaction, then run the code in the if
            if (model.transactionGuid == Guid.Empty)
            {
                //Run insert by creating new guid here and rest of sql query
                model.transactionGuid = Guid.NewGuid();
                SQL = "INSERT INTO transactions (transactionGuid, userGuid, transDate, transPayedTo, transNote, transCategory, transPayedAmount, transDepositAmount, transIsVisible) Values (";
                SQL += $"\"{model.transactionGuid}\", ";
                SQL += $"\"{userGuid}\", ";
                SQL += $"\"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\", ";
                SQL += $"\"{model.transPayedTo}\", ";
                SQL += $"\"{model.transNote}\", ";
                SQL += $"\"{model.transCategoryGuid}\", ";
                SQL += $"{model.transAmount}, ";
                SQL += $"{1})";
                new DBConnection().ExecuteMySQL(SQL);
            }
            //If trying to update transaction, then run the code in the else
            else
            {
                //Run update
                SQL = "UPDATE transactions SET ";
                SQL += $"transDate = \"{model.transDate.ToString("yyyy-MM-dd hh:mm:ss")}\", ";
                SQL += $"transPayedTo = \"{model.transPayedTo}\", ";
                SQL += $" transNote = \"{model.transNote}\", ";
                SQL += $"transCategory = \"{model.transCategoryGuid}\", ";
                SQL += $"transAmount = {model.transAmount}, ";
                SQL += $"WHERE transactionGuid = \"{model.transactionGuid}\" ";
                SQL += $"AND userGuid = \"{userGuid}\" ";
                new DBConnection().ExecuteMySQL(SQL);
            }

            return model;
        }

        //unsure whether or not to use this function or the toggleCategory function below, the one below handles both setting cat to active and 'deleted' (hidden)
        public TransactionModel DeleteTransaction(TransactionModel model, Guid userGuid)
        {
            string SQL = "";
            if (model.transactionGuid != Guid.Empty && userGuid != Guid.Empty)
            {
                SQL = "UPDATE transactions SET ";
                SQL += $" transIsVisible = {0} ";
                SQL += $"WHERE transactionGuid = \"{model.transactionGuid}\" ";
                SQL += $"AND userGuid = \"{userGuid}\"";
                new DBConnection().ExecuteMySQL(SQL);
            }
            //not sure if i need to pass whole model or just parts of it
            return model;
        }
    }
}

