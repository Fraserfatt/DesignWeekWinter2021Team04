using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Startup : MonoBehaviour
{
    public SceneReference StartupScene;
    private void Start()
    {
        bool found = false;
        for(int i = 0; i < SceneManager.sceneCount; i++)
        {
            if(SceneManager.GetSceneAt(i).name == StartupScene.SceneName)
            {
                found = true;
                break;
            }
        }

        if(found == false)
        {
            Scene scene = SceneManager.GetSceneByPath(StartupScene);
            if(scene.isLoaded == false)
            {
                SceneLoader.Instance.LoadScene(StartupScene);
            }
        }
    }
}