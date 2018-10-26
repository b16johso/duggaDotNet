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
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT alien.IDkod,alienNamn.namn,alien.farlighet,alien.rasNamn FROM alien,alienNamn WHERE alien.IDkod=alienNamn.IDkod;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable alienTable = ds.Tables["result"];
            dbcon.Close();

            return alienTable;
        }

        public DataTable GetAlienDemography()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("CALL alienDemografi();", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable demographyTable = ds.Tables["result"];
            dbcon.Close();

            return demographyTable;
        }

        public DataTable SearchAliens(string name)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT alien.IDkod,alienNamn.namn,alien.farlighet,alien.rasNamn FROM alien,alienNamn WHERE alien.IDkod=alienNamn.IDkod AND alienNamn.namn LIKE @NAME;", dbcon);
            adapter.SelectCommand.Parameters.AddWithValue("@NAME", "%" + name + "%");
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable alienTable = ds.Tables["result"];
            dbcon.Close();
            return alienTable;
        }
    }
}
