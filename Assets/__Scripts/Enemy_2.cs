using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy
{
    // integer to hold random direction
    int direction;
    public void Start()
    {
        // random number generator to select direction
        int rand = Random.Range(0, 2);
        // set direction to 1 or -1 depending on randomized output
        if (rand == 0)
        {
            direction = -1;
        } else
        {
            direction = 1;
        }
        
    }

    public override void Move()
    {
        
        Vector3 tempPos = pos;
        // move down with constant speed
        tempPos.y -= speed * Time.deltaTime;
        // randomly move left or right with constant speed at 45 degree angle
        tempPos.x -= speed * direction * Time.deltaTime;
        pos = tempPos;
    }
}
