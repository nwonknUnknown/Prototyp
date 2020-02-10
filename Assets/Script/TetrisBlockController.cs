﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TetrisBlockController : MonoBehaviour
{
    //Denna koden hanterar Tetris kubernas rörelse i spelet. Man kan återanvända dessa för spelaren, men kommer behöva ändra så att spelarens bil kan åka uppåt och neråt, samt att bilen ska inte åka neråt varje frame. 
    public float fallTime = 1; //Handles the time when the block is falling down.
    public float fallSpeed = 1; //Handles the speed, that the object is falling in.
    [SerializeField] bool allowRotation = true; //If rotation should be true on this object.
    [Header("The Z axes are the ones you whant to edit in order to edit the speed of the objekt.")]
    [SerializeField] Vector3 goingDownSpeed; //Hastighet Z
    [SerializeField] Vector3 goingLeftSpeed; //Hastighet X
    [SerializeField] Vector3 goingRightSpeed;//Hastighet -X
    bool tetrisCubeMoving = true;
    int count; //The amount of tetrisblocks in this row.  
    Game gameManager; //Game class.

    // Update is called once per frame
   public void Update()
    {  

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += goingRightSpeed;

            if (CheckIsValidPosition())
            {
            }
            else
            {
                transform.position -= goingRightSpeed;
            }
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += goingLeftSpeed;

            if (CheckIsValidPosition())
            {
            }
            else
            {
                transform.position -= goingLeftSpeed;
            }

        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 90, 0);
            if (CheckIsValidPosition())
            {

            }
            else
            {
                transform.Rotate(0, -90, 0);
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fallTime >= fallSpeed)
        {
            transform.position += goingDownSpeed;

            if (CheckIsValidPosition())
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log($"Position {transform.position}");  transform.position -= goingDownSpeed;
            }

            fallTime = Time.time;

        }

    }

    bool CheckIsValidPosition()
    {
        foreach(Transform tetrisCube in transform)
        {         
            if (Game.CheckIsInsideGrid(tetrisCube.position) == false) //If the tetris cube is inside the grid.
            {
               return false;
            }
        }
        return true;
    }

}