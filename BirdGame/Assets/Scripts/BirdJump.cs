using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdJump : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 10f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            direction = Vector3.up * strength;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0;
        transform.position = position;
        direction = Vector3.zero;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle") 
        {
            FindObjectOfType<GameManager>().GameOver();
        } 
        else if (other.gameObject.tag == "Scoring") 
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
