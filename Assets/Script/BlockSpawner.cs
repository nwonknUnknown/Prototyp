using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] Transform parent;
    private bool blockActivate;

    private float lifeTime  = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(blockActivate == true)
        {
            Vector3 scale;
            GameObject go;
            go = Instantiate(block, parent);
            scale.x = scale.y = scale.z = 10;
            go.transform.localScale = scale;
            blockActivate = false;

        }
    }

    public void SwitchOn()
    {
        blockActivate = true;
    }
}
