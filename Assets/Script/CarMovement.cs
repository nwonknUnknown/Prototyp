using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode moveUp;
    public KeyCode moveDown;

    public float horizVelocity = 0;
    public float verticVelocity = 0;
    public string moveLock = "n";
    public int laneNumberX = 3;
    public int laneNumberY = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVelocity, 0, verticVelocity);

        if ((Input.GetKeyDown(moveLeft) && (laneNumberX > 1) && (moveLock == "n")))
        {
            horizVelocity = -4;
            StartCoroutine(stopSlide());
            laneNumberX -= 1;
            moveLock = "y";
        }
        if ((Input.GetKeyDown(moveRight) && (laneNumberX < 5) && (moveLock == "n")))
        {
            horizVelocity = +4;
            StartCoroutine(stopSlide());
            laneNumberX += 1;
            moveLock = "y";
        }
        if ((Input.GetKeyDown(moveUp) && (laneNumberY < 10) && (moveLock == "n")))
        {
            verticVelocity = +6;
            StartCoroutine(stopSlide());
            laneNumberY += 1;
            moveLock = "y";
        }
        if ((Input.GetKeyDown(moveDown) && (laneNumberY > 0) && (moveLock == "n")))
        {
            verticVelocity = -6;
            StartCoroutine(stopSlide());
            laneNumberY -= 1;
            moveLock = "y";
        }

        IEnumerator stopSlide()
        {
            yield return new WaitForSeconds(0.5f);
            horizVelocity = 0;
            verticVelocity = 0;
            moveLock = "n";
        }
    }
}