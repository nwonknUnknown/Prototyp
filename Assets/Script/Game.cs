using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject[] tetrisObjects;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNextTetrisBlock();
    }
   
    public void SpawnNextTetrisBlock()
    {
        Instantiate(tetrisObjects[Random.Range(0, tetrisObjects.Length)], transform.position, Quaternion.identity);
    }
}
