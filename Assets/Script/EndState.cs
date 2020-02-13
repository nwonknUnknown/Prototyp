using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class EndState : States
{
    private LoseCondition scene;

    public EndState()
    {
         scene.CheckGameOver();

    }
    public override States Do()
    {
        return null;
    }
}
