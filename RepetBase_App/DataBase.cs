using System;
using System.Data.SqlClient;

namespace DataBase_App
{
    internal class DataBase
    {
        public SqlConnection sqlConnection = new SqlConnection(@"Data Source=510-10; Initial Catalog=RepCenter; Integrated Security=true");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        
        public SqlConnection GetConnection()
        {
            return sqlConnection;
            
        }
    }
}
