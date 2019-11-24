﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Child")
        {

            if(!collision.gameObject.GetComponent<Child>().immortal)
            {
                Destroy(collision.gameObject.transform.parent.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

}
