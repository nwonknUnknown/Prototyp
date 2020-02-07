using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockController : MonoBehaviour
{
    //Denna koden hanterar Tetris kubernas rörelse i spelet. Man kan återanvända dessa för spelaren, men kommer behöva ändra så att spelarens bil kan åka uppåt och neråt, samt att bilen ska inte åka neråt varje frame. 
    public float fallTime = 1; //Handles the time when the block is falling down.
    public float fallTimeReset = 1; //Used to reset the tetris blocks timer between falling down. It's public, which means it can be changed overtime with the GameManager script.
    [SerializeField] bool allowRotation = true; //If rotation should be true on this object.
    Bounds tetrisBounds; //Bounds for the tetrisblock.
    Bounds groundBox; //Bounds for the ground.
    [Header ("The Z axes are the ones you whant to edit in order to edit the speed of the objekt.")]
    [SerializeField] Vector3 goingDownSpeed;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider boxCollider; 
        BoxCollider groundCollider;
        GameObject nameOfCollision; 
        nameOfCollision = GameObject.Find("Ground"); //To get acces to the gameobject we want to check collision with.
        if (nameOfCollision == null) //To check if it's null.
        {
            return;
        }
        groundCollider = nameOfCollision.GetComponent<BoxCollider>(); //Getting the boxcollider of the groundcollider.
        if(groundCollider == null) //To check if it's null.
        {
            return;
        }
        groundBox = groundCollider.bounds; //We are storing the bounds of the boxcollider for the road.
        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            return; 
        }
        tetrisBounds = boxCollider.bounds; //We are storing the bounds of the boxcollider for this tetris block.
        if (goingDownSpeed.x < 0)
        {
            goingDownSpeed.x = -1;
        }

    }
    // Update is called once per frame
    void Update()
    {

        fallTime -= Time.deltaTime; //Makes falltime be minus the deltatime.

        float playerInputX;
        playerInputX = Input.GetAxis("Horizontal");
        float playerInputZ;
        playerInputZ = Input.GetAxisRaw("Vertical");
        float playerInputRotate;
        playerInputRotate = Input.GetAxisRaw("Rotate");
        Vector3 position; //A vector we can use to calculate if the tetris block would enter another objekts bounds.  
        position = transform.position; //Inherenting the objects world position to the position varibale. 
       // Debug.Log($"{position.x + tetrisBounds.extents.x } {groundBox.max.x} ");     
        if (position.x + tetrisBounds.extents.x + playerInputX > groundBox.max.x) //If the objekt would move pass the max bounds of the ground.
        {
            playerInputX = groundBox.max.x - (position.x + tetrisBounds.extents.x); //Make so that it moves as close as possible. 
        }       
        if(position.x - tetrisBounds.extents.x + playerInputX < groundBox.min.x) //If the object would move pass the min bounds of the ground.
        {
            playerInputX = groundBox.min.x - (position.x - tetrisBounds.extents.x); //Make so that it moves as close as possible.
        }
        position.x += (playerInputX); //Move the player forward. 

        if((fallTime <= 0) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            position += goingDownSpeed; //Move the tetris block down when the user presses the down arrow. 
            fallTime = fallTimeReset; //Resets the timer so that the tetris block doesen't constantly go down faster and faster.
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (allowRotation)
            {

                if (position.x - tetrisBounds.extents.x + playerInputRotate > groundBox.max.x)
                {
                    playerInputRotate = groundBox.max.x - (position.x - tetrisBounds.extents.x);
                }
                if (position.x - tetrisBounds.extents.x + playerInputRotate < groundBox.min.x) //If the object would move pass the min bounds of the ground.
                {
                    playerInputRotate = groundBox.min.x - (position.x - tetrisBounds.extents.x); //Make so that it moves as close as possible.
                }
                transform.Rotate(0, 90, 0); //Rotates this object. Needs to be fixed to not be able to rotate when stuck in terrain.
            }
        }
        transform.position = position; //Reseting the transform. 
    }
}

