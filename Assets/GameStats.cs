﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStats : MonoBehaviour
{
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives > 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }  
    }
}
