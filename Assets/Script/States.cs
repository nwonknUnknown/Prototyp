using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    public virtual States Do()
    {
        return this;
    }

}
class WaitState : States
{
    public override States Do()
    {
        return this;
    }
}

class TetrisGameState : States
{
    public override States Do()
    {
        return base.Do();
    }

}

class EndState : States
{
    public override States Do()
    {
        return base.Do();
    }
}




