using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitState : States
{
    private float timeLeft = 4.0f;
    private Text txt;


    GameObject Frame;
    GameState blockManager;
    GameObject car;

    private bool spawnCar = true;

    public WaitState()
    {
        txt = GameObject.Find("Wait_Text").GetComponent<Text>();

        Frame = GameObject.Find("Next_Block_Object");
        blockManager = new GameState();

        GameObject tetrisBlock = blockManager.SpawnNextTetrisBlock();

    }

    public override States Do()
    {
        timeLeft -= Time.deltaTime;

        if (spawnCar)
        {
            car = GameObject.Instantiate(Resources.Load($"Prefab/Car 1", typeof(GameObject)) as GameObject, GameObject.Find("Car_Spawn_Point").transform);
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
