using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJump : MonoBehaviour
{
    [SerializeField] float velocity = 1;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * velocity;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if(otherCollider.tag == "Obstacle")
        {
            Debug.Log("Game Over");
            FindObjectOfType<GameManager>().GameOver();
        }else if (otherCollider.gameObject.tag == "Score")
        {
            FindObjectOfType<GameManager>().ScoreCounter();
        }
    }
}
