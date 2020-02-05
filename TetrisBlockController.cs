using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlockController : MonoBehaviour
{
    //Denna koden hanterar Tetris kubernas rörelse i spelet. Man kan återanvända dessa för spelaren, men kommer behöva ändra så att spelarens bil kan åka uppåt och neråt, samt att bilen ska inte åka neråt varje frame. 

    float fallTime = 0; //Handles the time when the block is falling down.
    public float fallSpeed = 1; //The speed the tetris block is falling with. It's public, which means it can be changed overtime with the GameManager script.
    [SerializeField] bool allowRotation = true; //If rotation should be true on this object.
    Bounds tetrisBounds;
    Bounds groundBox;


    // Start is called before the first frame update
    void Start()
    {
        BoxCollider boxCollider;
        BoxCollider groundCollider;
        GameObject nameOfCollision;

        nameOfCollision = GameObject.Find("Ground");
        if (nameOfCollision == null)
        {
            //return;
        }
        groundCollider = nameOfCollision.GetComponent<BoxCollider>();

        if(groundCollider == null)
        {
            //return;
        }
        groundBox = groundCollider.bounds;

        boxCollider = GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            //return; 
        }
        tetrisBounds = boxCollider.bounds;
    }

    // Update is called once per frame
    void Update()
    {    
        // CheckUserInputs(); //Calls the CheckUserInputs function.
        float playerInput;
        playerInput = Input.GetAxisRaw("Horizontal");
        Vector3 position;
        position = transform.position;
        Debug.Log($"{position.x + tetrisBounds.extents.x } {groundBox.max.x} ");
        
        if (position.x + tetrisBounds.extents.x + playerInput > groundBox.max.x) 
        {
            playerInput = groundBox.max.x - (position.x + tetrisBounds.extents.x);
        }
        
        if(position.x - tetrisBounds.extents.x + playerInput < groundBox.min.x)
        {
            playerInput = groundBox.min.x - (position.x - tetrisBounds.extents.x);
        }
        position.x += (playerInput);



        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fallTime >= fallSpeed)
        {
            transform.position += new Vector3(0, 0, -1); //Uses transform to move the block down 1 unit through the Z axis.

            fallTime = Time.time; //Resets the timer so that the tetris block doesen't constantly go down.
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (allowRotation)
            {
                transform.Rotate(0, 90, 0); //Rotates this object. Needs to be fixed to not be able to rotate when stuck in terrain.
            }
        }

        transform.position = position;
    }
}

