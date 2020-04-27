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
        int Score = ScoreScript.ScoreValue;
        string temp = newText;
        string conn = "URI=file:" + Application.dataPath + "/sql.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); 
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "INSERT INTO ScoreTable(Name,Score)" + $"VALUES('{temp}',{Score})";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
    }

}
