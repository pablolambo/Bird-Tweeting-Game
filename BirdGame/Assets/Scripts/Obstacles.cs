using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge = -11f;
    public float destroyTime = 5f;
    private float offset = 1f;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(-11f, 0f, 0f)).x - offset;
    }

    private void Update()
    {
        transform.position +=  Vector3.left * (speed * Time.deltaTime);

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
    
    
}
