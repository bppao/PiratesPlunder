using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CLevelManager : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        Debug.Log("Load level requested for: " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void Quit()
    {
        Debug.Log("Quit requested!");

        // NOTE: This does not quit out of the editor in play-mode, so it will
        // appear to do nothing. But this does work in the standalone exe.
        Application.Quit();
    }
}
