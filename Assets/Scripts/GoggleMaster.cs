using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WANOBINS.NHTI_GJ_2019
{
    [RequireComponent(typeof(Camera))]
    public class GoggleMaster : MonoBehaviour
    {
        new private Camera camera;
        [SerializeField]
        private Transform reference;
        public GoggleSlave slave;
        // Start is called before the first frame update
        void Start()
        {
            camera = transform.GetComponent<Camera>();
            slave.SetMaster(this);
        }

        // Update is called once per frame
        void Update()
        {
            if (slave.active)
            {
                //Set Master based on Slave
                transform.position = (slave.transform.position - slave.reference.position) + reference.position;
                transform.rotation = slave.transform.rotation;
                slave.camera.Render();
            }
            else
            {
                //Set Slave based on Master
                slave.transform.position = (transform.position - reference.position) + slave.reference.position;
                slave.transform.rotation = transform.rotation;
                camera.Render();
            }
        }

        public void SendPlayer(Transform player)
        {
            camera.enabled = false;
            slave.RecievePlayer(player);
        }

        public void RecievePlayer(Transform player)
        {
            camera.enabled = true;
        }
    }
}
