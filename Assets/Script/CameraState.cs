using UnityEngine;

class CameraState : States
{


    private Transform StartCamera;
    private Camera camera;
    private Vector3 StartOffset;
    private Vector3 moveVector;

    private float transition = 0.0f;
    private float animationDuration = 3.0f;
    private Vector3 animationOffset = new Vector3(0, 5, 5);

    public CameraState()
    {
        camera = Camera.main;
        StartCamera = GameObject.Find("Car_Spawn_Point").transform;
        StartOffset = camera.transform.position - StartCamera.position;
    }

    public override States Do()
    {
        if (transition > 1.0f)
        {
                return (new WaitState());
        }
        else
        {
            moveVector = StartCamera.position + StartOffset;
            moveVector.x = 0;
            moveVector.y = Mathf.Clamp(moveVector.y, 4, 6);

            //Animation start of game
            camera.transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += Time.deltaTime * 1 / animationDuration;
            camera.transform.LookAt(StartCamera.position + Vector3.up);

        }
            return this;
    }
}




