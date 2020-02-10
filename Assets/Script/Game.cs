using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public int gridHeight = 20;
    public int gridWidth = 10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GroundEnter(int counts)
    {
        if (counts == 5)
        {
            //Destroy(child);
            //Add score here.
        }
    }

    public bool CheckIsInsideGrid(Vector3 pos) //Checking if a certain object is within the grid or not and returns the value to reset it self.
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.z >= 0);
    }

    public Vector3 Round(Vector3 pos) //Checks so that no "mathf" errors occur.
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.z));
    }
}
