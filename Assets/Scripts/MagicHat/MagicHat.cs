using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHat : MonoBehaviour
{
    public GameObject magicHat;
    // Start is called before the first frame update
    void Start()
    {
        magicHat = GameObject.FindGameObjectWithTag("MagicHat");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            List<Loot> drop = magicHat.GetComponent<LootTable>().LootReceived();
            Instantiate(drop[0].item.PhysicalItem, new Vector3(transform.position.x, transform.position.y + 10f), Quaternion.identity);
        }
    }
}
