using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;

        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; //Left & Right movement
    }
}
