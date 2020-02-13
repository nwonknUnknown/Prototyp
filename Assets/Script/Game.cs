using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject[] tetrisObjects;
    [SerializeField] Transform parent;
    [SerializeField] Vector3 rotate;

    // Start is called before the first frame update
    void Start()
    {

    }
   
    public void SpawnNextTetrisBlock()
    {
        GameObject go;
        go = Instantiate(tetrisObjects[Random.Range(0, tetrisObjects.Length)], transform.position, Quaternion.identity);
        go.transform.Rotate(rotate);


    }

   /* public void FrameBlock(GameObject block)
    {
        Vector3 scale;
        GameObject go;
        go = Instantiate(block, parent);
        scale.x = scale.y = scale.z = 10;
        go.transform.localScale = scale;
        go.transform.Rotate(-5, -15, -2);
    }*/
}
