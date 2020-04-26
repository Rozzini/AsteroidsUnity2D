using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ship;
using Score;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;

public class EndGameScript : MonoBehaviour
{

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
   
    public void Restart()
    {
        SceneManager.LoadScene("Game"); 
    }

    public void SendToDb(string newText)
    {
        //int temp = int.TryParse(newText, out _);

        string temp = newText;

        string conn = "URI=file:" + Application.dataPath + "/sql.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); 
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO ScoreTable(Score)" + "VALUES('asdsad')";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);
            int rand = reader.GetInt32(2);

            Debug.Log("value= " + "aa" + "  name =" + "bb" + "  random =" + 1);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

}
