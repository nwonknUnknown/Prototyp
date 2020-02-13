using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthMeter : MonoBehaviour
{
    [SerializeField] Slider healthBar; // being able to affect the Health_Bar slider

    int[] checks = { 0, 20, 40, 60, 80, 100, 101 };

    [SerializeField] ScoreCounter playerScore;
    [SerializeField] LoseCondition scene;
    GameState state;
    public float invincibilityLength;
    public float invincibilityCounter;
    MeshRenderer playerRender;
    MeshRenderer newRender;
    GameObject car;
    private float flashCounter;
    public float flashLength = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        car.GetComponent<MeshRenderer>();
        healthBar.maxValue = checks[checks.Length - 2];
        healthBar.minValue = checks[0];
        // Setting all relevant healthvalues.
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.X))
            {
                changeHealth(-2);
                Debug.Log("damage");
                if (healthBar.value == 0) // load gameoverscreen
                {
                    //  DestroyObject("Car");
                    playerScore.DisableScore();
                    state.GameOver();
                }
                else
                {
                    invincibilityCounter = invincibilityLength;

                    playerRender.enabled = false;

                    flashCounter = flashLength;
                }
            }
            if (Input.GetKeyDown(KeyCode.C))
            {
                changeHealth(3);
                Debug.Log("hp");
            }
        if(invincibilityCounter >= 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;
            if (flashCounter <= 0)
            {
                playerRender.enabled = !playerRender.enabled;
                flashCounter = flashLength;
            }

            if (invincibilityCounter <= 0)
            {
                playerRender.enabled = true;
            }

        }

    }



    public void changeHealth(float changeValue)
    {
        healthBar.value += changeValue;

        for (int i = 0; i < checks.Length - 1; i++)
        {
            Debug.Log($"{i} Health value: {healthBar.value} {checks[i]}");
            if(healthBar.value >= checks[i] && healthBar.value < checks[i+1])
            {
                playerScore.ChangeModifier(i);

                break;
            }
        }
    }
}
