using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    CanvasGroup _pauseCanvas;
    CanvasGroup _gameOverCanvas;

    public bool _isGameOver;
    bool _isGamePaused;

    private void OnLevelWasLoaded(int level)
    {
        InitGame();
    }

    void Awake()
    {
        InitGame();
    }

    void InitGame()
    {
        _pauseCanvas = GameObject.Find("Pause").GetComponent<CanvasGroup>();
        CanvasOff(_pauseCanvas);
        Time.timeScale = 1;
        _isGamePaused = false;
        _isGameOver = false;


        if (!(SceneManager.GetActiveScene().name == "GameScene"))
            return;

        _gameOverCanvas = GameObject.Find("GameOver").GetComponent<CanvasGroup>();
        CanvasOff(_gameOverCanvas);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void GameOver()
    {
        Debug.Log("Gameover");
        CanvasOn(_gameOverCanvas);

        int highScore;
        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        if (PlayerPrefs.GetInt("HighScore") < ScoreManager.ins.Score())
        {
            highScore = ScoreManager.ins.Score();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highScore = PlayerPrefs.GetInt("HighScore");

        _gameOverCanvas.transform.Find("HighScore").GetComponent<Text>().text = "최고 점수 : " + highScore.ToString();
        _gameOverCanvas.transform.Find("CurrentScore").GetComponent<Text>().text = "현재 점수 : " + ScoreManager.ins.Score().ToString();

        _isGameOver = true;
    }

    public void Pause()
    {
        if (_isGamePaused)
        {
            CanvasOff(_pauseCanvas);
            Time.timeScale = 1;
            _isGamePaused = false;
        }
        else
        {
            CanvasOn(_pauseCanvas);
            Time.timeScale = 0;
            _isGamePaused = true;
        }
    }

    void CanvasOff(CanvasGroup canvas)
    {
        canvas.alpha = 0;
        canvas.interactable = false;
        canvas.blocksRaycasts = false;
    }

    void CanvasOn(CanvasGroup canvas)
    {
        canvas.alpha = 1;
        canvas.interactable = true;
        canvas.blocksRaycasts = true;
    }
}
