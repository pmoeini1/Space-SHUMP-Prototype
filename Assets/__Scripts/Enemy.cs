using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // speed of enemy
    public float speed = 10f;
    // check if in bounds
    private BoundsCheck bndChek;

    void Awake()
    {
        // set up BoundsCheck
        bndChek = GetComponent<BoundsCheck>();
    }
    // get a Vector3 from position
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        } set
        {
            this.transform.position = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move function
        Move();
        // destroy if enemy is too far right, left, or down
        if (bndChek != null && (bndChek.offDown||bndChek.offLeft||bndChek.offRight))
        {
            Destroy(gameObject);
        }
    }
    // override in subclasses; method for enemy movement
    public virtual void Move() { }
    
    void OnCollisionEnter(Collision coll)
    {
        GameObject otherGO = coll.gameObject;
        // destory enemy and projectile if they collide
        if (otherGO.tag == "ProjectileHero")
        {
            Destroy(otherGO);
            Destroy(gameObject);
        }
    }
}
