using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {


    public GameObject pauseMenu;
    public static bool isPaused = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f; // 0f - 1f
                isPaused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f; // 0f - 1f
                isPaused = true;
            }

        }
             
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }
}
