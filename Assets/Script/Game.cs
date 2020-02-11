using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
   [SerializeField] public static int gridHeight = 20;
   [SerializeField] public static int gridWidth = 10;
   [Tooltip("Skriv _exakta_ namnet för den tetris kub som ska spawna")]
   [SerializeField] string [] tetrisCubeName;
   [SerializeField] Transform spawnPoint;
    private static Transform[,] grid = new Transform[gridWidth, gridHeight];
    GameObject[] tetrisCubes; 
    protected bool count;

    // Start is called before the first frame update
    void Start()
    {
        tetrisCubes = new GameObject[tetrisCubeName.Length];
        
        for (int i = 0; i < tetrisCubeName.Length; ++i)
        {
            tetrisCubes[i] = Resources.Load($"Prefab/{tetrisCubeName[i]}", typeof(GameObject)) as GameObject;
        }
        {
           
        }
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

    public void UpdateGrid(TetrisBlockController tetrisBlocks) //Uppdaterar valbara platser i griden.
    {    
        foreach(Transform children in transform)
        {

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
        GameObject nextTetrisBlockString = tetrisCubes[Random.Range(0, tetrisCubeName.Length)];

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

    public Vector3 Round (Vector3 pos)
    {
        return new Vector3(Mathf.Round(pos.x), Mathf.Round(pos.z));
    }

}
