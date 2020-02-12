using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    
    [SerializeField] Transform parent;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FrameBlock(GameObject block)
    {
        Vector3 scale;
        GameObject go;
        go = Instantiate(block, parent);
        scale.x = scale.y = scale.z = 10;
        go.transform.localScale = scale;
        go.transform.Rotate(-5, -15, -2);
    }
}
