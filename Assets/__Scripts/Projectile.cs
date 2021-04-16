using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    private BoundsCheck bndCheck;
    void Awake()
    {
        // set up BoundsCheck
        bndCheck = GetComponent<BoundsCheck>();
    }
   

    // Update is called once per frame
    void Update()
    {
        // if projectile goes off screen, destroy it
        if (bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }
}
