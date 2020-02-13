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
    GameObject car;

    private bool spawnCar = true;

    public WaitState()
    {
        txt = GameObject.Find("Wait_Text").GetComponent<Text>();
        blockManager = new GameState();

        Frame = GameObject.Find("Frame");
        block = Frame.GetComponentInChildren<Game>();
        block.SpawnNextTetrisBlock();

    }

    public override States Do()
    {
        timeLeft -= Time.deltaTime;

        if (spawnCar)
        {
            car = GameObject.Instantiate(Resources.Load($"Prefab/Car", typeof(GameObject)) as GameObject, GameObject.Find("Car_Spawn_Point").transform);
            spawnCar = false;
            Debug.Log("carishere");
        }
        if (timeLeft <= 0)
        {
            GameObject.Destroy(txt.gameObject);
            blockManager.FirstTime();
            return (blockManager);
            
        }
        txt.text = $"{Mathf.FloorToInt(timeLeft)}";
        return this;
    }
}
