using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1 : Enemy
{
    public override void Move()
    {
        Vector3 tempPos = pos;
        // make enemy move down in straight line with constant speed
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
