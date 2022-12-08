using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class nextScene : MonoBehaviour
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void LoadSceneName(string sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
