using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    public class SQLDataAccess
    {

        public void updateHighscore(int highscore)
        {
            int theHighScoreToBeInserted = highscore;

            //Inserts the FirstName variable into the db-table, HighscoreDB - in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HighscoreDB"].ToString());
            SqlCommand cmd = new SqlCommand();

            //cmd.CommandText = "INSERT INTO asd.dbo.Highscore (Id, CurrentHighscore) VALUES (198, @theHighScoreToBeInserted);";
            cmd.CommandText = "UPDATE asd.dbo.Highscore SET CurrentHighscore = CASE WHEN CurrentHighscore < @theHighScoreToBeInserted THEN @theHighScoreToBeInserted ELSE CurrentHighscore END" +
                              " WHERE Id=198;";
            //Uses the FirstName variable and creates a new sql variable for use in the sql commandtext
            cmd.Parameters.Add("@theHighScoreToBeInserted", SqlDbType.Int).Value = theHighScoreToBeInserted;

            cmd.Connection = conn;

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public int LoadHighscore()
        {
            //Inserts the FirstName variable into the db-table, HighscoreDB - in the web.config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HighscoreDB"].ToString());
            SqlCommand cmd = new SqlCommand();
            int currentHighscore = 0;

            //cmd.CommandText = "INSERT INTO asd.dbo.Highscore (Id, CurrentHighscore) VALUES (198, @theHighScoreToBeInserted);";
            cmd.CommandText = "SELECT CurrentHighscore FROM asd.dbo.Highscore WHERE Id=198;";

            cmd.Connection = conn;

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                currentHighscore = reader.GetInt32(0);
            }

            conn.Close();

            return currentHighscore;
        }
    }
}