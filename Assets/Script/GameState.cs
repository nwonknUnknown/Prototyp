using UnityEngine;
using UnityEngine.UI;

class GameState : States
{
    [SerializeField] GameObject[] tetrisObjects;
    [SerializeField] Transform parent;
    [SerializeField] Vector3 rotate;
    private TetrisBlockController saved;
    GameObject block;
    ScoreCounter score;
    GameObject scoreboard;
    CarMovement car;
    GameObject carObject;

    private bool gameOver;
    private bool firstTime = false;

    public GameState(GameObject frameBlock)
    {
        scoreboard = GameObject.Find("HighscoreCounter");
        score = scoreboard.GetComponent<ScoreCounter>();

        block = frameBlock;
    }

    public override States Do()
    {
        if (firstTime)
        {
            carObject = GameObject.Find("Car(Clone)");
            car = carObject.GetComponent<CarMovement>();

            car.SetEnabled(true);
            score.EnableScore();
            MoveTetrisBlock(block.gameObject, GameObject.Find("Block_Spawn_Point").transform.position);
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
        go = Instantiate(tetrisObjects[Random.Range(0, tetrisObjects.Length)], transform.position, Quaternion.identity);
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




