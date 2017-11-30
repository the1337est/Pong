using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public Text Player1Score;
    public Text Player2Score;
    public Text Result;

    public int MaxScore;

    int score1;
    int score2;

    Ball ball;
    public bool Over = false;

    public int Score1
    {
        get
        {
            return score1;
        }
        set
        {
            score1 = value;
            Player1Score.text = score1.ToString();
            if (score1 == MaxScore)
            {
                Over = true;
                Gameover(1);
            }
            else
            {
                ball.Restart();
            }
        }
    }

    public int Score2
    {
        get
        {
            return score2;
        }
        set
        {
            score2 = value;
            Player2Score.text = score2.ToString();
            if (score2 == MaxScore)
            {
                Over = true;
                Gameover(2);
            }
            else
            {
                ball.Restart();
            }
        }
    }


    void Awake ()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(Instance);
            }
        }

        ball = FindObjectOfType<Ball>();
	}

    private void Update()
    {
        if (Over)
        {
            if (Input.anyKeyDown)
            {
                Reset();
            }
        }
    }

    public void AddScore(PlayerType pType, int points)
    {
        switch (pType)
        {
            case PlayerType.PlayerOne:
                score1 += points;
                break;
            case PlayerType.PlayerTwo:
                score2 += points; 
                break;
            default:
                break;
        }
    }

    void Gameover(int player)
    {
        Over = true;
        if (player == 1)
        {
            Result.text = "Player 1 Wins!";
        }
        else
        {
            Result.text = "Player 2 Wins!";
        }
    }

    private void Reset()
    {
        Over = false;
        Score1 = 0;
        Score2 = 0;
        ball.Restart();
        Result.text = "";
    }

}