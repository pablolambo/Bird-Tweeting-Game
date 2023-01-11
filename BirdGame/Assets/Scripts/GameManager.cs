using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver = true;
    public BirdJump bird;

    public TMP_Text scoreText;
    public GameObject playButton;
    public TMP_Text GameOverText;
    private int score;

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
    }
}
