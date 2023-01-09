using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public void GameOver()
    {
        Debug.Log("Game over");
    }

    public void ScoreCounter()
    {
        score++;
    }
}
