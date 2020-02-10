using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TetrisBlockController : MonoBehaviour
{
    //Denna koden hanterar Tetris kubernas rörelse i spelet. Man kan återanvända dessa för spelaren, men kommer behöva ändra så att spelarens bil kan åka uppåt och neråt, samt att bilen ska inte åka neråt varje frame. 
    public float fallTime = 1; //Handles the time when the block is falling down.
    public float fallSpeed = 1; //Handles the speed, that the object is falling in.
    [SerializeField] bool allowRotation = true; //If rotation should be true on this object.
    Bounds tetrisBounds; //Bounds for this tetrisblock.
    Bounds tetrisObjectsInSceneName; //Bounds for all tetrisblocks on the scene.
    Bounds groundBox; //Bounds for the ground.
    [Header("The Z axes are the ones you whant to edit in order to edit the speed of the objekt.")]
    [SerializeField] Vector3 goingDownSpeed;
    [SerializeField] Vector3 goingLeftSpeed;
    [SerializeField] Vector3 goingRightSpeed;
    bool tetrisCubeMoving = true;
    [SerializeField] int count; //The amount of tetrisblocks in this row.  
    Game rowCalculate;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
   public void Update()
    {  
        //This is old version: 
        //fallTime -= Time.deltaTime; //Makes falltime be minus the deltatime.
        //float playerInputX;
        //playerInputX = Input.GetAxis("Horizontal");
        //float playerInputZ;
        //playerInputZ = Input.GetAxisRaw("Vertical");
        //float playerInputRotate;
        //playerInputRotate = Input.GetAxisRaw("Rotate");
        //Vector3 position; //A vector we can use to calculate if the tetris block would enter another objekts bounds.  
        //position = transform.position; //Inherenting the objects world position to the position varibale. 
        //Debug.Log($"{position.x + tetrisBounds.extents.x } {groundBox.max.x} ");     
        //if (position.x + tetrisBounds.extents.x + playerInputX > groundBox.max.x && tetrisCubeMoving) //If the objekt would move pass the max bounds of the ground.
        //{
        //    playerInputX = groundBox.max.x - (position.x + tetrisBounds.extents.x); //Make so that it moves as close as possible. 
        //}       
        //if(position.x - tetrisBounds.extents.x + playerInputX < groundBox.min.x && tetrisCubeMoving) //If the object would move pass the min bounds of the ground.
        //{
        //    playerInputX = groundBox.min.x - (position.x - tetrisBounds.extents.x); //Make so that it moves as close as possible.
        //}
        //if (tetrisCubeMoving)
        //{
        //    position.x += (playerInputX); //Move the player forward. 
        //}
        //if (fallTime <= 0 && tetrisCubeMoving)
        //{
        //    fallTime = fallTimeReset;
        //    position += goingDownSpeed; //Move the tetris block down when the user presses the down arrow. 
        //}
        //if ((position.z - tetrisBounds.extents.z + playerInputZ < groundBox.min.z) && tetrisCubeMoving)
        //{           
        //    playerInputZ = groundBox.min.z - (position.z - tetrisBounds.extents.z); //Make so that it moves as close as possible.
        //    tetrisCubeMoving = false;
        //    rowCalculate.GroundEnter(++count);
        //}
        //if (tetrisCubeMoving)
        //{
        //    position.z += (playerInputZ); //Move the player forward.  
        //    if (position.z - tetrisBounds.extents.z < groundBox.min.z)
        //    {
        //        tetrisCubeMoving = false;
        //        rowCalculate.GroundEnter(++count);
        //    }
        //}
        //if (Input.GetKeyDown(KeyCode.UpArrow) && tetrisCubeMoving)
        //{
        //    if (allowRotation)
        //    {
        //        if (position.x - tetrisBounds.extents.x + playerInputRotate > groundBox.max.x)
        //        {
        //            playerInputRotate = groundBox.max.x - (position.x - tetrisBounds.extents.x);
        //        }
        //        if (position.x - tetrisBounds.extents.x + playerInputRotate < groundBox.min.x) //If the object would move pass the min bounds of the ground.
        //        {
        //            playerInputRotate = groundBox.min.x - (position.x - tetrisBounds.extents.x); //Make so that it moves as close as possible.
        //        }
        //        transform.Rotate(0, 90, 0); //Rotates this object. Needs to be fixed to not be able to rotate when stuck in terrain.
        //    }
        //}
        //transform.position = position; //Reseting the transform.

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
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fallTime >= fallSpeed)
        {
            transform.position += goingDownSpeed;

            if (CheckIsValidPosition())
            {

            }
            else
            {
                transform.position -= goingDownSpeed;
            }

            fallTime = Time.time;


        }

    }

    bool CheckIsValidPosition()
    {
        foreach(Transform tetrisCube in transform)
        {
            Vector3 pos = FindObjectOfType<Game>().Round(tetrisCube.position); //Check is a tetris is inside the grid.

            if (FindObjectOfType<Game>().CheckIsInsideGrid(pos) == false) //If the tetris cube is inside the grid.
            {
               return false;
            }
        }
        return true;
    }

}