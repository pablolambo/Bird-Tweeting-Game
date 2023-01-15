using UnityEngine;
using Random = UnityEngine.Random;
public class BreadSpawner : ObstacleSpawner
{
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
