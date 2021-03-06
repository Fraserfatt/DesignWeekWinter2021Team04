using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : Singleton<MenuManager>
{
    private Dictionary<string, Menu> MenuList = new Dictionary<string, Menu>();

    public T GetMenu<T>(MenuClassifier menuClassifier) where T : Menu
    {
        Menu menu;
        if(MenuList.TryGetValue(menuClassifier.menuName, out menu))
        {
            return (T)menu;
        }
        return null;
    }

    public void AddMenu(Menu menu)
    {
        if(MenuList.ContainsKey(menu.menuClassifier.menuName))
        {
            Debug.Assert(false, $"Menu is already registered {menu.menuClassifier.menuName}");
        }
        MenuList.Add(menu.menuClassifier.menuName, menu);
    }
    
    public void Remove(Menu menu)
    {
        MenuList.Remove(menu.menuClassifier.menuName);
    }



    public void showMenu(MenuClassifier classifier, string options = "")
    {
        Menu menu;
        if(MenuList.TryGetValue(classifier.menuName, out menu))
        {
            menu.OnShowMenu(options);
        }
    }

    public void hideMenu(MenuClassifier classifier, string options = "")
    {
        Menu menu;
        if (MenuList.TryGetValue(classifier.menuName, out menu))
        {
            menu.OnHideMenu(options);
        }
    }
}
