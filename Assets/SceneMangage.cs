using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMangage : MonoBehaviour
{
    public void ChangeLevel(string lvlToLoad)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(lvlToLoad);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
