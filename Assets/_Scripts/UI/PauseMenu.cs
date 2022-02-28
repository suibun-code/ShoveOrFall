using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool gameIsPaused = false;

    public void OnPause(InputValue value)
    {
        if (gameIsPaused)
            Resume();
        else
            Pause();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseCanvas.SetActive(false);
        gameIsPaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseCanvas.SetActive(true);
        gameIsPaused = true;
    }
}
