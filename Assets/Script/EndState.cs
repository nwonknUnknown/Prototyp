using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class EndState : States
{

    public EndState()
    {
        SceneManager.LoadScene("GameOver");
    }
    public override States Do()
    {
        return null;
    }
}
