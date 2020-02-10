using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
   [SerializeField] public static int gridHeight = 20;
   [SerializeField] public static int gridWidth = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNextTetrisBlock();
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



    static public bool CheckIsInsideGrid(Vector3 pos) //Checking if a certain object is within the grid or not and returns the value of the current position of a gameobject in relation to the grid.
    {
        return (pos.x >= 0 && pos.x < gridWidth && pos.z >= 0 && pos.z < gridHeight );
    }

    string SpawnNextTetrisBlock()
    {
        int randomTetrisBlock = Random.Range(1, 8);

        string randomTetrisObject = "Tetris_Cube_1";

        switch (randomTetrisBlock)
        {
            case 1:
                randomTetrisObject = "";
                break;
            case 2:
                randomTetrisObject = "";
                break;
            case 3:
                randomTetrisObject = "";
                break;

        }
        return randomTetrisObject;
    }

}
