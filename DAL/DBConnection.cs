using System.Data;
using System.Data.SqlClient;

namespace FinanceTrackingApp.DAL
{
    public class DBConnection
    {
        //Access DB for query actions
        public DataTable GetDataTable(string SQL)
        {
            try
            {
                //Connect to DB
                string connectionString = null;
                SqlConnection sqlCon;
                connectionString = "Server=localhost;UserID=admin;Password=password;Database=FinancialTrackingApp";
                sqlCon = new SqlConnection(connectionString);

                //open DB stream and do some stuff
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand(SQL, sqlCon);
                sql_cmnd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(sql_cmnd);
                DataTable DBResults = new DataTable();
                da.Fill(DBResults);

                //close DB stream
                sqlCon.Close();
                return DBResults;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: ", ex);
            }
        }

        //Access DB for query actions
        public void ExecuteMySQL(string SQL)
        {
            try
            {
                //Connect to DB
                string connectionString = null;
                SqlConnection sqlCon;
                connectionString = "Server=financial-tracking.mysql.database.azure.com;UserID=ftAdmin1;Password=U%cv694DaWHPYZBB&5SNouW!UjPf6xQ6aUi#6$Xg;Database=financial_tracking_app";
                sqlCon = new SqlConnection(connectionString);

                //open DB stream and do some stuff
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand(SQL, sqlCon);
                sql_cmnd.CommandType = CommandType.Text;

                // execute sql command with no return
                sql_cmnd.ExecuteNonQuery();

                //close DB stream
                sqlCon.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: ", ex);
            }
        }
    }
}
