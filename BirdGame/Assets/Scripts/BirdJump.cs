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
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle")) 
        {
            FindObjectOfType<GameManager>().GameOVer();
        } 
        else if (other.gameObject.CompareTag("Scoring")) 
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
