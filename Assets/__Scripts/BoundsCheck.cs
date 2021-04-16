using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{
    // keep GameObject on screen
    // set radius of how close to edge object can be
    public float radius = 10f;
    public bool keepOnScreen = true;
    // width of camera
    public float camWidth;
    // height of camera
    public float camHeight;
    public bool isOnScreen = true;
    // know which part of screen object is off
    public bool offLeft, offRight, offUp, offDown;

    void Awake()
    {
        // set height of camera
        camHeight = Camera.main.orthographicSize;
        // set width fo camera
        camWidth = Camera.main.aspect * camHeight;
    }


    void LateUpdate()
    {
        // keep object in limits of camera - radius
        Vector3 pos = transform.position;
        isOnScreen = true;
        offDown = offLeft = offRight = offUp = false;
        // see if object went too far right
        if (pos.x > camWidth - radius)
        {
            pos.x = camWidth - radius;
            offRight = true;
        }
        // see if object went too far left
        if (pos.x < -camWidth + radius)
        {
            pos.x = -camWidth + radius;
            offLeft = true;
        }
        // see if object went too far up
        if (pos.y > camHeight - radius)
        {
            pos.y = camHeight - radius;
            offUp = true;
        }
        // see if object went too far down
        if (pos.y < -camHeight + radius)
        {
            pos.y = -camHeight + radius;
            offDown = true;
        }
        // check if object is on screen
        isOnScreen = !(offDown || offLeft || offRight || offUp);
        // check if object should stay in screen, and keep on screen if so
        if (keepOnScreen && !isOnScreen)
        {
            transform.position = pos;
            isOnScreen = true;
            offUp = offRight = offLeft = offDown = false;
        }
        
    }

    void OnDrawGizmos()
    {
        // draw bounds in scene
        if (!Application.isPlaying)
        {
            // return nothing if game is not playing
            return;
        }
        Vector3 boundSize = new Vector3(camWidth * 2, camHeight * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, boundSize);
    }
}
