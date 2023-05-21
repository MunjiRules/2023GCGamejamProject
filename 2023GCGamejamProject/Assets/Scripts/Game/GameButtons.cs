using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameButtons : MonoBehaviour
{
    Button _returnButton;
    Button _restartButton;
    Button _toMainButton;
    Button _playButton;
    Button _exitButton;

    void Start()
    {
        _returnButton = transform.Find("Return")?.GetComponent<Button>();
        _restartButton = transform.Find("Restart")?.GetComponent<Button>();
        _toMainButton = transform.Find("ToMain")?.GetComponent<Button>();
        _playButton = transform.Find("Play")?.GetComponent<Button>();
        _exitButton = transform.Find("Exit")?.GetComponent<Button>();

        _returnButton?.onClick.AddListener(OnClickReturnButton);
        _restartButton?.onClick.AddListener(OnClickRestartButton);
        _toMainButton?.onClick.AddListener(OnClickToMainButton);
        _playButton?.onClick.AddListener(OnClickRestartButton);
        _exitButton?.onClick.AddListener(OnClickExitButton);
    }


    public void OnClickReturnButton()
    {
        GameManager.ins.Pause();
    }

    public void OnClickRestartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickToMainButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
