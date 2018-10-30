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

        public DataTable GetAllRaces()
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT namn FROM ras;", dbcon);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "result");
            DataTable raceTable = ds.Tables["result"];
            dbcon.Close();

            return raceTable;
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

        
        public void ClassifyRace(string race)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            if (race != "Hemligstämplat")
            {
                string classifyString = "CALL hemligstämplaRas(@race);";
                MySqlCommand sqlCmd = new MySqlCommand(classifyString, dbcon);
                sqlCmd.Parameters.AddWithValue("@race", race);
                sqlCmd.ExecuteNonQuery();
            }
            dbcon.Close();
        }

        //Add new alien to database
        public void InsertAlien(string IDkod, string namn, int farlighet, string rasNamn)
        {
            MySqlConnection dbcon = new MySqlConnection(connectionString);
            dbcon.Open();
            string insertAlienString = "INSERT INTO alien(IDkod, farlighet, rasNamn) values (@IDkod, @farlighet, @rasNamn);";
            string insertNameString = "INSERT INTO alienNamn(namn, IDkod) values (@namn, @IDkod);";
            MySqlCommand insertAlien = new MySqlCommand(insertAlienString, dbcon);
            MySqlCommand insertName = new MySqlCommand(insertNameString, dbcon);
            insertAlien.Parameters.AddWithValue("@IDkod", IDkod);
            insertAlien.Parameters.AddWithValue("@farlighet", farlighet);
            insertAlien.Parameters.AddWithValue("@rasNamn", rasNamn);
            insertName.Parameters.AddWithValue("@namn", namn);
            insertName.Parameters.AddWithValue("@IDkod", IDkod);
            insertAlien.ExecuteNonQuery();
            insertName.ExecuteNonQuery();
            dbcon.Close();
        }
    }
}
