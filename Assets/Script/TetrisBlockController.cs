using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TetrisBlockController : MonoBehaviour
{
    //Denna koden hanterar Tetris kubernas rörelse i spelet. Man kan återanvända dessa för spelaren, men kommer behöva ändra så att spelarens bil kan åka uppåt och neråt, samt att bilen ska inte åka neråt varje frame. 
    Vector3 rotationPoint; 
    float prievousFallTime = 1; //Handles the time when the block is falling down.
    [SerializeField] float fallTime = 1; //Handles the speed, that the object is falling in.
    public static int height = 20; //The height of the grid.
    public static int width = 10; //The width of the grid.
    [SerializeField] bool allowRotation = true; //If rotation should be true on this object.
    [Header("The Z axes are the ones you whant to edit in order to edit the speed of the objekt.")]
    [SerializeField] Vector3 goingDownSpeed; //Hastighet Z
    [SerializeField] Vector3 goingLeftSpeed; //Hastighet X
    [SerializeField] Vector3 goingRightSpeed;//Hastighet -X
    private static Transform[,] grid = new Transform[width, height]; //Positionen för tetrisblocken i griden.

    // Update is called once per frame
    public void Update()
    {            
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += goingRightSpeed;

                if (!CheckIsValidPosition()) //If you would try to perfome a illegal move.
                {
                    transform.position -= goingRightSpeed; //Move back.
                }             
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += goingLeftSpeed;

                if (!CheckIsValidPosition())
                {
                    transform.position -= goingLeftSpeed;
                }

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
            if (allowRotation == true)
            {   
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 1, 0), 90); //Rotate from the middle of the object.
                if (!CheckIsValidPosition())
                {
                    transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 1, 0), -90); //Rotate back.
                }
            }
                
            }

            if (Time.time - prievousFallTime > (Input.GetKeyDown(KeyCode.DownArrow) ? fallTime / 10 : fallTime)) 
            {
                transform.position += goingDownSpeed;

                if (!CheckIsValidPosition())
                {
                transform.position -= goingDownSpeed;
                AddToGrid();
                CheckIfLineIsFull();
                FindObjectOfType<Game>().SpawnNextTetrisBlock();    
                enabled = false;
                }
             
                prievousFallTime = Time.time;

            }     
    }

    void CheckIfLineIsFull()
    {
        for(int i = height -1; i >= 0; i--) //Looking through the top of the grid and the bottom to see if there is full grid.
        {
            if (HasLine(i)) //If there is a line that is full.
            {
                DeleteLine(i); //Delete line
                RowDown(i); //Move one row down.
            }
        }
    }   

    bool HasLine(int i) //If a line of tetrisblocks exist here.
    {
        for(int j = 0; j < width; j++) //Looking through all of them.
        {
            if(grid[j,i] == null) //If it woud find null.
            {
                return false;
            }
            
        }
        return true; //Return true if a line of tetrisblocks has been found.
    }

    void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++) //Looking through all of the tetrisblocks that should be destroyed.
        {
            Destroy(grid[j, i].gameObject); //Destroy the tetrisblocks that are in a line.
            grid[j,i] = null; //The area they where in becomes null and are now open for new tetrisblocks.
        }
    }

    void RowDown(int i)
    {
        for (int y = i; y < height; y++) //Looking through the height of the tetrisblocks that need to move down in a column.
        {           
            for(int j = 0; j < width; j++) //Then we do the same for the width of the tetrisblocks in one row.
            {
                if(grid[j,y] != null) //If it would return false.
                {
                    grid[j, y - 1] = grid[j, y]; //Reduces index i by 1.
                    grid[j, y] = null; //The position becomes free for a new tetriscube to go down in.
                    grid[j, y - 1].transform.position -= goingDownSpeed; //Moves down the row.
                }
            }
        }
    }

    void AddToGrid() //Adds tetrisblocks that have fallen to the grid.
    {
        foreach (Transform children in transform) //Look though all of the childrens and add children to array if needed.
        {
            int roundedX = Mathf.RoundToInt(children.transform.position.x); //Round there X value.
            int roundedZ = Mathf.RoundToInt(children.transform.position.z); //Round there Z value.

            grid[roundedX, roundedZ] = children; //Add the transform of the childrens
        }
    }
    bool CheckIsValidPosition()
    {
        foreach(Transform children in transform) //Look though all of the childrens.
        {

            int roundedX = Mathf.RoundToInt(children.transform.position.x); //Round there X value.
            int roundedZ = Mathf.RoundToInt(children.transform.position.z); //Round there Z value.

            if(roundedX < 0 || roundedX >= width || roundedZ < 0 || roundedZ >= height ) //If one is bigger then the grid.
            {
                return false; //Return false.
            }

            if (grid[roundedX,roundedZ] != null) //If this position is allready taken by a child object.
            {
                return false;
            }
        }
        return true; //Return true if no tetrisblock (this object) is outside of the grid.
    }

}