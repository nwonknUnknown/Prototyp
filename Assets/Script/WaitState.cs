using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitState : States
{
    private float timeLeft = 4.0f;
    private Text txt;


    GameObject Frame;
    Game block;
    GameState blockManager;

    public WaitState()
    {
        txt = GameObject.Find("Wait_Text").GetComponent<Text>();
        blockManager = new GameState();
        block.SpawnNextTetrisBlock(true);
    }

    public override States Do()
    {

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            return (blockManager);
        }
        txt.text = $"{Mathf.FloorToInt(timeLeft)}";

        return this;
    }
}
