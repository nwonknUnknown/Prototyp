using UnityEngine;
using UnityEngine.UI;

class GameState : States
{
    Game block;
    ScoreCounter score;

    private bool oneTime;

    public GameState()
    {
        score.EnableScore();
    }

    public override States Do()
    {

        if (oneTime == true) // When the car is dead we enter EndState
        {
            score.DisableScore();
            return (new EndState());
        }
        return this;
    }

    public void Switch()
    {
        oneTime = true;
    }




}




