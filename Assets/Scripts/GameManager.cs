using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int ballCount = 3;
    private int currentBallCount = 0;

    [SerializeField]
    private UILabel highScore;
    [SerializeField]
    private UILabel currentScore;
    [SerializeField]
    private UILabel balls;
    [SerializeField]
    private String file;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            currentScore.text = "Current Score: " + score;
        }
    }

    public int BallCount
    {
        get
        {
            return currentBallCount;
        }
        set
        {
            currentBallCount = value;
            balls.text = "Balls: " + currentBallCount;
        }
    }

    // Use this for initialization
    void Start()
    {
        UpdateHighScore();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame()
    {
        Score = 0;
        BallCount = ballCount;
    }

    public void EndGame()
    {
        string conn = "URI=file:" + Application.dataPath + "/" + file; //Path to database.
        IDbConnection dbconn = new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "INSERT INTO `Scores` VALUES (" + Score + ");";
        dbcmd.ExecuteNonQuery();
        dbcmd.Dispose();
        dbconn.Close();

        foreach (Transform t in transform)
            GameObject.Destroy(t.gameObject);

        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        string conn = "URI=file:" + Application.dataPath + "/" + file; //Path to database.
        IDbConnection dbconn = new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        dbcmd.CommandText = "SELECT max(score) FROM Scores";
        IDataReader reader = dbcmd.ExecuteReader();
        reader.Read();
        int value = reader.GetInt32(0);
        reader.Close();
        dbcmd.Dispose();
        dbconn.Close();

        highScore.text = "High Score: " + value;
    }
}
