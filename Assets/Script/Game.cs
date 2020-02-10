using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
   [SerializeField] public static int gridHeight = 20;
   [SerializeField] public static int gridWidth = 10;
   [Tooltip("Skriv _exakta_ namnet för den tetris kub som ska spawna")]
   [SerializeField] string [] tetriscube;
   [SerializeField] Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNextTetrisBlock();
    }

    public void GroundEnter(int counts)
    {
        if (counts == 5)
        {
            //Destroy(child);
            //Add score here.
        }
    }

    public void SpawnNextTetrisBlock()
    {
        string s = GetRandomTetrisBlock();
        GameObject nextTetrisBlockString = Resources.Load($"Prefab/{s}", typeof(GameObject)) as GameObject;
        Debug.Log($"TetrisBlock {s}");

        if (nextTetrisBlockString == null)
        {
            Debug.Log("Null");
            return;  
        }

        GameObject nextTetrisBlock = Instantiate(nextTetrisBlockString, spawnPoint);

    }

    static public bool CheckIsInsideGrid(Vector3 pos) //Checking if a certain object is within the grid or not and returns the value of the current position of a gameobject in relation to the grid.
    {
        return (pos.x >= 0 && pos.x < gridWidth && pos.z >= 0 && pos.z < gridHeight );
    }

    string GetRandomTetrisBlock()
    {      
        return tetriscube[Random.Range(0, tetriscube.Length)];
    }

}
