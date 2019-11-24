using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHat : MonoBehaviour
{
    public GameObject magicHat;
    public GameObject magicHatObjSpawn;
    // Start is called before the first frame update
    void Start()
    {
        magicHat = GameObject.FindGameObjectWithTag("MagicHat");
        magicHatObjSpawn = GameObject.FindGameObjectWithTag("MagicHatObjSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("X: " + magicHatObjSpawn.transform.position.x + " | Y: " + magicHatObjSpawn.transform.position.y);
            List<Loot> drop = magicHat.GetComponent<LootTable>().LootReceived();
            Instantiate(drop[0].item.PhysicalItem, new Vector3(magicHatObjSpawn.transform.position.x, magicHatObjSpawn.transform.position.y - .1f, magicHatObjSpawn.transform.position.z), Quaternion.identity);
        }
    }

    public void SpawnMagic()
    {
        List<Loot> drop = magicHat.GetComponent<LootTable>().LootReceived();
        Instantiate(drop[0].item.PhysicalItem, new Vector3(magicHatObjSpawn.transform.position.x, magicHatObjSpawn.transform.position.y - .1f, magicHatObjSpawn.transform.position.z), Quaternion.identity);
    }

}
