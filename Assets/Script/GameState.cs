using UnityEngine;
using UnityEngine.UI;

class GameState : States
{
    Game block;
    ScoreCounter score;
    GameObject scoreboard;

    private bool gameOver;

    public GameState()
    {
        scoreboard = GameObject.Find("HighscoreCounter");
        score = scoreboard.GetComponent<ScoreCounter>();
        score.EnableScore();
    }

    public override States Do()
    {

        if (gameOver) // When the car is dead we enter EndState
        {
            score.DisableScore();
            return (new EndState());
        }
        return this;
    }

    public void Switch()
    {
        gameOver = true;
    }




}




