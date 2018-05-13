using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour {

    //used to connect to our database
    private string connectionString;

    private List<HighScore> highScores = new List<HighScore>();

    public GameObject scorePrefab;

    public Transform scoreParent;

    public int topRanks;

    public InputField enterName;

    public GameObject nameDialog;

    public ScoreManager sm;



	// Use this for initialization
	void Start () {

        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.db";
        CreateTable();
        ShowScores();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            nameDialog.SetActive(!nameDialog.activeSelf);
        }
		
	}

    private void CreateTable()
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("CREATE TABLE if not exists HighScores ( PlayerID INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT, Score INTEGER)");
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
                // dbConnection.Dispose();


            }
        }
    }

    public void EnterName(int score)
    {
        if (enterName.text != string.Empty)
        {
            //score = UnityEngine.Random.Range(1, 100);
            float scorey = sm.scoreCount;
            Debug.Log(scorey);
            score = (int)scorey;
            Debug.Log(score);
            InsertScore(enterName.text, score);
            enterName.text = string.Empty;
            ShowScores();
        }
    }

    private void InsertScore(string name, int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\", \"{1}\")", name, newScore);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();
               // dbConnection.Dispose();

                
            }
        }

    }

    private void GetScores()
    {

        highScores.Clear(); //clear list

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * from Highscores";
                string sqlQuery2 = "SELECT* FROM HighScores ORDER BY Score DESC";
                dbCmd.CommandText = sqlQuery;
                dbCmd.CommandText = sqlQuery2;

                using (IDataReader reader = dbCmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        //Debug.Log(reader.GetString(1)+ " " + reader.GetInt32(2));
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1)));
                        
                    }

                    dbConnection.Close();
                    reader.Close();

                }
            }
        }
    }

    private void DeleteScore(int id)
    {

        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();

            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", id);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();


            }
        }
       
    }

    private void ShowScores()
    {
        GetScores();

        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            Destroy(score);
        }
        for (int i = 0; i < topRanks; i++)
        {

            if (i <= highScores.Count - 1)
            {


                GameObject tmpObjec = Instantiate(scorePrefab);

                HighScore tmpScore = highScores[i];

                tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());

                tmpObjec.transform.SetParent(scoreParent);

                tmpObjec.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }
        }
    }
}

//SELECT* FROM HighScores ORDER BY Score DESC
