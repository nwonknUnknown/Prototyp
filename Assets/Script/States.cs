using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    public virtual States Do()
    {
        return this;
    }

    // Start is called before the first frame update
    void Start()
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

    class FrameBlockState : States
    {
        public override States Do()
        {
            return base.Do();
        }
    }

    class BackgroundState : States
    {
        
    }

    class EndState : States
    {
        public override States Do()
        {
            return base.Do();
        }
    }




