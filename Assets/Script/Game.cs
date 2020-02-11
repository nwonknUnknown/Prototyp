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
    public static Transform[,] grid = new Transform[gridWidth, gridHeight];
    protected bool count;

    // Start is called before the first frame update
    void Start()
    {
        count = true;
        SpawnNextTetrisBlock(count);        
    }

    public void GroundEnter(int counts)
    {
        if (counts == 5)
        {
            //Destroy(child);
            //Add score here.
        }
    }

    public void UpdateGrid(TetrisBlockController tetrisBlocks)
    {
        for(int z = 0; z < gridHeight; ++z)
        {
            for(int x = 0; x < gridWidth; ++x)
            {
                if(grid[x,z] != null)
                {
                    if (grid[x, z].parent == tetrisBlocks.transform)
                    {
                        grid[x, z] = null;
                    }
                }
                
            }
        }
        foreach (Transform obj in tetrisBlocks.transform)
        {
            //Position of tetrisblock.
            Vector3 pos = Round(obj.position);
           if(pos.z < gridHeight)
            {
                grid[(int)pos.x, (int)pos.z] = obj;
            }
        }
    }

    public Transform GetTransformAtGridPosition(Vector3 pos)
    {
        if(pos.y > gridHeight - 1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x,(int)pos.z];
        }
    }

    public void SpawnNextTetrisBlock(bool count)
    {
        string s = GetRandomTetrisBlock();
        GameObject nextTetrisBlockString = Resources.Load($"Prefab/{s}", typeof(GameObject)) as GameObject;
        Debug.Log($"TetrisBlock {s}");

        if (nextTetrisBlockString == null)
        {
            Debug.Log("Null");              
        }
        
        if (count)
        {
            GameObject nextTetrisBlock = Instantiate(nextTetrisBlockString, spawnPoint);
            count = false;
        }



    }

    static public bool CheckIsInsideGrid(Vector3 pos) //Checking if a certain object is within the grid or not and returns the value of the current position of a gameobject in relation to the grid.
    {
        return (pos.x >= 0 && pos.x < gridWidth && pos.z >= 0 && pos.z < gridHeight );
    }

    string GetRandomTetrisBlock()
    {      
        return tetriscube[Random.Range(0, tetriscube.Length)];
    }

    public Vector3 Round (Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.z));
    }

}
