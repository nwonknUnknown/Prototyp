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
    private string[] tetrisBlockNames = { "Tetris_Cube_1", "Tetris_Cube_2", "Tetris_Cube_3", "Tetris_Cube_4", "Tetris_Cube_5", "Tetris_Cube_6", "Tetris_Cube_7" };
    private bool gameOver;
    private bool firstTime = false;

    public GameState()
    {
        scoreboard = GameObject.Find("HighscoreCounter");
        score = scoreboard.GetComponent<ScoreCounter>();


        framePos = GameObject.Find("Block_Spawn_Point").transform.position;


        tetrisObjects = new GameObject[tetrisBlockNames.Length];
        for(int i = 0; i<tetrisBlockNames.Length; i++)
        {
            tetrisObjects[i] = Resources.Load($"Prefab/{tetrisBlockNames[i]}") as GameObject;

        }

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
        block = GameObject.Instantiate(tetrisObjects[Random.Range(0, tetrisObjects.Length)], framePos, Quaternion.identity);
        block.transform.Rotate(rotate);
        saved = block.GetComponent<TetrisBlockController>();
        saved.SetMovable(false);
        return block;

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




