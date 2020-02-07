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
    public string moveLock = "n";
    public int laneNumber = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horizVelocity, 0, 0);

        if ((Input.GetKeyDown(moveLeft) && (laneNumber > 0) && (moveLock == "n")))
        {
            horizVelocity = -2;
            StartCoroutine(stopSlide());
            laneNumber -= 1;
            moveLock = "y";
        }
        if ((Input.GetKeyDown(moveRight) && (laneNumber < 4) && (moveLock == "n")))
        {
            horizVelocity = +2;
            StartCoroutine(stopSlide());
            laneNumber += 1;
            moveLock = "y";
        }
    }
    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(0.5f);
        horizVelocity = 0;
        moveLock = "n";
    }
}
