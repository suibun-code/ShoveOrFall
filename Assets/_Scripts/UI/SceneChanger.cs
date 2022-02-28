using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void ChangeScene(string scene)
    {
        if (PauseMenu.gameIsPaused)
            Time.timeScale = 1f;

        SceneManager.LoadScene(scene);
    }
}
