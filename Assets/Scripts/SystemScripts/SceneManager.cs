using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public void LoadScene(string name,LoadSceneMode mode = LoadSceneMode.Single)
    {
        SceneManager.LoadScene(name,mode);
    }
    public void UnloadScene(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }

    public void NextScene(string name)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(name);
    }

    public void ReloadScene()
    {
        NextScene(SceneManager.GetActiveScene().name);
    }
}
