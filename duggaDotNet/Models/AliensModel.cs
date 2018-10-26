using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace duggaDotNet.Models
{
    public class AliensModel
    {
        private string connectionString = "Server=localhost; Port=3306; Database=b16johso; Uid=root; Pwd=; SslMode=none;";

        public DataTable GetAllAliens()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM alien;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable alienTable = ds.Tables["result"];
            dbcon.Close();

            return alienTable;
        }
    }
}
