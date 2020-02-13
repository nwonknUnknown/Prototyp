using UnityEngine;
using UnityEngine.UI;

class GameState : States
{
    GameObject[] tetrisObjects;
    [SerializeField] Transform parent;
    [SerializeField] Vector3 rotate;
    private TetrisBlockController saved;
    GameObject block;
    ScoreCounter score;
    GameObject scoreboard;
    CarMovement car;
    GameObject carObject;
    Vector3 framePos;
    private string[] tetrisBlockNames = {"Cube_Block", "L_Block", "Line_Block", "T_Block", "Z_Block", "Mirror_L_Block", "Mirror_Z_Block" };
    private bool gameOver;
    private bool firstTime = false;

    public GameState()
    {
        scoreboard = GameObject.Find("HighscoreCounter");
        score = scoreboard.GetComponent<ScoreCounter>();


        framePos = GameObject.Find("Block_Spawn_Point").transform.position;




    }

    public override States Do()
    {
        if (firstTime)
        {
            carObject = GameObject.Find("Car 1(Clone)");
            car = carObject.GetComponent<CarMovement>();

            car.SetEnabled(true);
            score.EnableScore();
            MoveTetrisBlock(block, framePos);
            firstTime = false;
        }



        if (gameOver) // When the car is dead we enter EndState
        {
            score.DisableScore();
            return (new EndState());
        }
        return this;
    }

    public GameObject SpawnNextTetrisBlock()
    {
        GameObject go;
        go = GameObject.Instantiate(tetrisObjects[Random.Range(0, tetrisObjects.Length)], framePos, Quaternion.identity);
        go.transform.Rotate(rotate);
        saved = go.GetComponent<TetrisBlockController>();
        saved.SetMovable(false);
        return go;

    }

    public void MoveTetrisBlock(GameObject block, Vector3 position)
    {
        block.transform.position = position;
        saved.SetMovable(true);
    }

    public void GameOver()
    {
        gameOver = true;
    }

    public void FirstTime()
    {
        firstTime = true;
    }






}




