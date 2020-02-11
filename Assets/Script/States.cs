using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    public virtual States Do() {
        return this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
    class WaitState : States
    {
        public override States Do()
        {
            return this;
        }
    }

    class FrameBlock : States
    {

    }




