using System.Collections;
using System.Collections.Generic;

public abstract class States
{
    public virtual States Do()
    {
        return null;
    }
}

class EndState : States
{
    private LoseCondition scene;
    public override States Do()
    {
        return null;
    }
}




