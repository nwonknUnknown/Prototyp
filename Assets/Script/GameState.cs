using UnityEngine;
using UnityEngine.UI;

class GameState : States
{
    Game block;
    ScoreCounter score;
    GameObject scoreboard;
    CarMovement car;
    GameObject carObject;

    private bool gameOver;
    private bool firstTime = false;

    public GameState()
    {
        scoreboard = GameObject.Find("HighscoreCounter");
        score = scoreboard.GetComponent<ScoreCounter>();
    }

    public override States Do()
    {
        if (firstTime)
        {
            carObject = GameObject.Find("Car(Clone)");
            car = carObject.GetComponent<CarMovement>();

            car.SetEnabled(true);
            score.EnableScore();
            firstTime = false;
        }

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

    public void FirstTime()
    {
        firstTime = true;
    }






}




