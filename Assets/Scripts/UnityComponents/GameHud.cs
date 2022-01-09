using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHud : MonoBehaviour
{
    const string SceneName = "SampleScene";

    public GameObject StartGame;
    public GameObject GameOver;
    public TMP_Text Score;
    public string FormatScore = "Score: {0}";

    public void Awake()
    {
        StartGame.SetActive(true);
        GameOver.SetActive(false);
        Score.gameObject.SetActive(false);
    }

    public void OnStartGameClick()
    {
        StartGame.SetActive(false);
        Score.gameObject.SetActive(true);
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

    public void OnNewGameClick()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void SetScore(int value)
    {
        Score.text = string.Format(FormatScore, value);
    }
}
