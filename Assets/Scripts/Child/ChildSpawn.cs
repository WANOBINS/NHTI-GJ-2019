using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildSpawn : MonoBehaviour
{
    public GameObject child;
    public int lastSpawn;
    public float spawnTimer;
    public float nextSpawnTime;
    public GameObject[] spawns;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            SpawnChild();
            nextSpawnTime += spawnTimer;
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
