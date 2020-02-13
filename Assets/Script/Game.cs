using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject[] tetrisObjects;
    [SerializeField] Transform parent;
    [SerializeField] Vector3 rotate;
    private TetrisBlockController saved;

    // Start is called before the first frame update
    void Start()
    {

    }
   
    public GameObject SpawnNextTetrisBlock()
    {
        GameObject go;
        go = Instantiate(tetrisObjects[Random.Range(0, tetrisObjects.Length)], transform.position, Quaternion.identity);
        go.transform.Rotate(rotate);
        saved = go.GetComponent<TetrisBlockController>();
        saved.SetMovable(false);
        return go;

    }

    public void MoveTetrisBlock(GameObject block, Vector3 position)
    {
        block.transform.position = position;
        saved.SetMovable(true);
    }
}
