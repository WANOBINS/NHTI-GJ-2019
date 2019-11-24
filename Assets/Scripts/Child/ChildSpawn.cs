using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChildSpawn : MonoBehaviour
{
    public GameObject child;
    public int lastSpawn;
    public float spawnTimer;
    public float nextSpawnTime;
    public GameObject[] spawns;
    public int lives;

    void Start()
    {
        nextSpawnTime = Time.time + nextSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Time.time > nextSpawnTime)
        {
            SpawnChild();
            nextSpawnTime += spawnTimer;
        }

        if (lives < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    public void SpawnChild()
    {
        int spawnCount = spawns.Length;
        int spawnLoc = Random.Range(0, spawnCount);
        while (lastSpawn == spawnLoc)
        {
            spawnLoc = Random.Range(0, spawnCount);
        }
        lastSpawn = spawnLoc;

        Instantiate(child, spawns[spawnLoc].transform.position, Quaternion.identity);

    }

}
