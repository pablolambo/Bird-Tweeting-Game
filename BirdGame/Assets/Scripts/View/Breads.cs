using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breads : Obstacles
{
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(new Vector3(-11, 0f, 0f)).x - offset;
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
