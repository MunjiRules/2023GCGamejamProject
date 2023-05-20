using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public bool _isGameOver;
    bool _isGamePaused;

    void Start()
    {
        _isGameOver = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isGamePaused)
            {
                Time.timeScale = 1;

            }
            else
            {
                Time.timeScale = 0;

            }
        }
    }

    public void GameOver()
    {
        Debug.Log("Gameover");
        _isGameOver = true;
    }
}
