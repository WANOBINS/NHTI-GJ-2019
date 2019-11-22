
using UnityEngine;
using UnityEngine.SceneManagement;

namespace WANOBINS.NHTI_GJ_2019
{
    class SceneMerger: MonoBehaviour
    {
        GameObject Player;
        Camera PlayerCam;
        public string[] Scenes = new string[0]; //The assignment is just so Unity doesn't complain about unassigned vars when it's doing the assigning...

        void Start() {
            Player = GameObject.FindWithTag("Player");
            PlayerCam = Player.GetComponent<Camera>();
            PlayerCam.enabled = false;
            foreach(string s in Scenes)
            {
                SceneManager.LoadScene(s, LoadSceneMode.Additive);
            }
            PlayerCam.enabled = true;
        }
    }
}