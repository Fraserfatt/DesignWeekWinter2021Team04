using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    public MenuClassifier HUDMenu;
    public SceneReference LoadLevel;
    public SceneReference UIScene;
    public void OnLoadLevel()
    {
        MenuManager.Instance.showMenu(HUDMenu);
        MenuManager.Instance.hideMenu(menuClassifier);
        SceneLoader.Instance.LoadScene(LoadLevel);
        SceneLoader.Instance.UnloadScene(UIScene);
    }
}
