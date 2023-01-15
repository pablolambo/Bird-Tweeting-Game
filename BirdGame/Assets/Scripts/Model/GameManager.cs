using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = true;
    public Bird bird;
    
    public GameObject playButton;
    public TMP_Text GameOverText;
    
    private int score;
    public TMP_Text scoreText;
    private int bread;
    public TMP_Text breadText;
    private int HighScore;
    public TMP_Text HighScoreText;


    private void Start()
    {
        HighScoreText.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        bread = PlayerPrefs.GetInt("BreadAmount",0);
        LoadState();
    }

    private void LoadState()
    {
        PlayerPrefs.GetInt("BreadAmount",bread);
        breadText.text = bread.ToString();
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        isGameOver = false;
        PauseMenu.isPaused = false;
        score = 0;
        scoreText.text = score.ToString();
        AudioManager audioManager = AudioManager.Instance;
        audioManager.PlayBackgroundMusic();
        
        playButton.SetActive(false);
        GameOverText.gameObject.SetActive(false);

        Time.timeScale = 1;
        bird.enabled = true;
        
        Obstacles[] obstacles = FindObjectsOfType<Obstacles>();

        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i].gameObject);
        }
    }

    public void Pause()
    {
        PauseMenu.isPaused = true;
        Time.timeScale = 0;
        bird.enabled = false;
        AudioManager audioManager = AudioManager.Instance;
        audioManager.StopBackgroundMusic();
    }

    public void GameOver()
    {
        isGameOver = true;
        GameOverText.gameObject.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        if(score > PlayerPrefs.GetInt("HighScore",0))
        {
            PlayerPrefs.SetInt("HighScore",score);
            HighScoreText.text = score.ToString();
        }
    }

    public void IncreaseBreads()
    {
        bread++;
        breadText.text = bread.ToString();
        PlayerPrefs.SetInt("BreadAmount",bread);
        PlayerPrefs.Save();
    }
}
