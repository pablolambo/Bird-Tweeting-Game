using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacles;
    public float spawnRate;
    public float miniHeight;
    public float maxHeight;
    
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject obstacle = Instantiate(obstacles, transform.position, Quaternion.identity);
        obstacle.transform.position += Vector3.up * Random.Range(miniHeight, maxHeight);
    }
}
