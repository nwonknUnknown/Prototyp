using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private float currentScore = 0;
    private float scoreModifier = 1;
    
    [SerializeField] Text score; //The text projects the players highscore.
    [SerializeField] Text block; // Text for next tetris block.
    private bool isEnabled; // A bool that will activate the scorecounting

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled) // Activates the scorecounting.
        {
            currentScore += 1 * Time.deltaTime * scoreModifier;
            score.text = $" Score: {Mathf.FloorToInt(currentScore)}";
        }
    }

    public void EnableScore()
    {
        isEnabled = true;
    }

    public void DisableScore()
    {
        isEnabled = false;
        score.text = $" Highscore: {Mathf.FloorToInt(currentScore)}";
    }

    public void ChangeModifier(float lifemod)
    {
        scoreModifier = lifemod;
        Debug.Log($"current modifier: {scoreModifier}");
    }

}
