using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    // set Hero
    public static Hero s;
    // set rotation and speed constants
    public float speed = 30;
    public float rotateY = -45;
    public float rotateX = 30;
    private GameObject lastTriggerGo = null;
    // declare projectile as game object
    public GameObject projectilePrefab;
    // set speed of projectile speed
    public float projectileSpeed = 40;

    // set Hero object
    void Awake()
    {
        if (s == null)
        {
            s = this;
        }
        else
        {
            // error message
            Debug.LogError("Failed to assign Hero");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Receive information from keyboard
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        // Chagnge transform based on axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;
        // Rotate ship
        transform.rotation = Quaternion.Euler(yAxis * rotateX, xAxis * rotateY, 0);
        // shoot projectile when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TempFire();
        }
    }

    public void TempFire()
    {
        // instantiate a projectile when spacebar is pressed
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        // put projectile at hero's position
        projGO.transform.position = transform.position;
        // make projectile into a rigidbody
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        // make projectile move up with constant velocity
        rigidB.velocity = Vector3.up * projectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        // find parent of gameObject hit by projectile
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        // if hit null, return nothing
        if (go == lastTriggerGo)
        {
            return;
        }
        lastTriggerGo = go;
        // if hit enemy, destroy enemy and hero
        if (go.tag == "Enemy")
        {
            Destroy(go);
            Destroy(this.gameObject);
            // reload scene
            SceneManager.LoadScene("_Scene_0");
        } 
    }
    
}
