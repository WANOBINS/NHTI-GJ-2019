using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WANOBINS.NHTI_GJ_2019
{
    [RequireComponent(typeof(Camera))]
    public class GoggleSlave : MonoBehaviour
    {
        public Transform reference;
        public bool active = false;
        new public Camera camera;
        GoggleMaster master;
        // Start is called before the first frame update
        void Start()
        {
            camera = transform.GetComponent<Camera>();
            camera.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetMaster(GoggleMaster master)
        {
            this.master = master;
        }

        public void RecievePlayer(Transform player)
        {
            enabled = true;
            camera.enabled = true;
        }

        public void SendPlayer(Transform player)
        {
            camera.enabled = false;
            enabled = false;
            master.RecievePlayer(player);
        }
    }
}
