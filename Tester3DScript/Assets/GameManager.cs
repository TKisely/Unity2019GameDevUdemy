﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public void GameOver()
    {
        isGameOver = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&isGameOver)
        {
            //GameScene reload
            SceneManager.LoadScene(1);
        }
    }
}
