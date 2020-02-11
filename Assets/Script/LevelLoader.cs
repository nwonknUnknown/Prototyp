﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(2));
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelIndex);
    }

}
