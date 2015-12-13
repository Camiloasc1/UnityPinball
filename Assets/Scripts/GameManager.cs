using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int ballCount = 3;
    public UILabel highScore;
    public UILabel currentScore;
    public UILabel balls;

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
            return ballCount;
        }
        set
        {
            ballCount = value;
            balls.text = "Balls: " + ballCount;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

    }

    public void EndGame()
    {

    }

}
