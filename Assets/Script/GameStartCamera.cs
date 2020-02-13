using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartCamera : MonoBehaviour
{
    private Transform StartCamera;
    private Vector3 StartOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    [SerializeField] ScoreCounter activateScore;

    // Start is called before the first frame update
    void Start()
    {
        StartCamera = GameObject.FindGameObjectWithTag("Car").transform;
        StartOffset = transform.position - StartCamera.position;
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = StartCamera.position + StartOffset;

        moveVector.x = 0;
        moveVector.y = Mathf.Clamp(moveVector.y, 8, 10);

        if (transition > 1.0f)
        {
            transform.position = moveVector;
            activateScore.EnableScore();
        }
        else
        {
            //Animation start of game
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            transform.LookAt(StartCamera.position + Vector3.up);

        }

        

    }
}
