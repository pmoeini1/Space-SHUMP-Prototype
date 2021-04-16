using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public static Main s;
    // create array of possible enemies
    public GameObject[] prefabEnemies;
    // set rate of enemy spawn to 1 every 2 seconds
    public float enemySpawnPerSecond = 0.5f;
    // set how close to edges enemies can spawn
    public float enemyDefaultPadding = 1.5f;
    // set up a BoundsCheck instance
    private BoundsCheck bndCheck;

    void Awake()
    {
        // set Main s to this
        s = this;
        bndCheck = GetComponent<BoundsCheck>();
        // invoke SpawnEnemy once every 2 seconds
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    
    public void SpawnEnemy()
    {
        // pick random enemy prefab
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);
        // position enemy at top of screen with random x position
        float enemyPadding = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }
        // set initial position for spawn enemy
        Vector3 pos = Vector3.zero;
        // put enemy between parameters of x-axis
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        // put enemy in random x position within parameters of x-axis
        pos.x = Random.Range(xMin, xMax);
        // put enemy at top
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;

        // invoke SpawnEnemy() again

        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
}
