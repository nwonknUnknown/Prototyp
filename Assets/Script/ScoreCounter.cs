using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private float currentScore = 0;
    
    [SerializeField] Text score; //The text projects the players highscore.
    private bool isEnabled; // A bool that will activate the scorecounting

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<Text>(); //getting the text compoment.
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled) // Activates the scorecounting.
        {
            currentScore += 1 * Time.deltaTime;
            score.text = $" Highscore: {Mathf.FloorToInt(currentScore)}";
        }
    }

    public void enableScore()
    {
        isEnabled = true;
    }

}
