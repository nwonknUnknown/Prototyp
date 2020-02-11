using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    States currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = new CameraState();

    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Do();
    }
}
