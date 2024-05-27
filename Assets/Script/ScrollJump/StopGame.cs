using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGame : MonoBehaviour
{
    public bool gameStoped = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & !gameStoped)
        {
            StopDeGame();

        }
        else if (Input.GetKeyDown(KeyCode.Escape) & gameStoped)
        {
            RunDeGame();
            gameStoped = false;
        }
        if(!gameStoped & Time.timeScale < 1)
        {
            Time.timeScale += 0.05f;
        }
        else if (!gameStoped & Time.timeScale > 1)
        {
            Time.timeScale = 1;
        }
    }
    public void StopDeGame()
    {
        Time.timeScale = 0;  
        gameStoped = true;
    }
    public void RunDeGame()
    {
        Time.timeScale = 1;
        gameStoped = false;
    }
}
