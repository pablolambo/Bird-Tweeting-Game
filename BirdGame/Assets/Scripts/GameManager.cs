using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
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
        score = 0;
        scoreText.text = score.ToString();
        
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
        Time.timeScale = 0;
        bird.enabled = false;
    }

    public void GameOver()
    {
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
