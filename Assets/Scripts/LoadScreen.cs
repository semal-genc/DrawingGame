using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreen : MonoBehaviour
{
    public string nextScene;

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
