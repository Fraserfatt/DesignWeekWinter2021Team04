using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Menu : MonoBehaviour
{
    public MenuClassifier menuClassifier;

    public enum StartingMenuStates
    {
        Ignore,
        Active,
        Disable
    }

    public StartingMenuStates startMenuState = StartingMenuStates.Active;
    public bool resetPosition = true;

    public UnityEvent OnRefreshMenu = new UnityEvent();

    private bool isOpen = false;
    public bool IsOpen
    {
        get
        {
            return isOpen;
        }
        set
        {
            isOpen = value;
            gameObject.SetActive(value);

            if(value == true)
            {
                OnRefreshMenu.Invoke();
            }
        }
    }

    public virtual void OnShowMenu(string options = "")
    {
        IsOpen = true;
    }

    public virtual void OnHideMenu(string options = "")
    {
        IsOpen = false;
    }

    protected virtual void Awake()
    {
        if(resetPosition == true)
        {
            var rectTransform = GetComponent<RectTransform>();
            rectTransform.localPosition = Vector3.zero;
        }
    }

    protected virtual void Start()
    {
        //Register with menu manager
        MenuManager.Instance.AddMenu(this);

        switch(startMenuState)
        {
            case StartingMenuStates.Active:
                isOpen = true;
                gameObject.SetActive(true);
                break;

            case StartingMenuStates.Disable:
                isOpen = false;
                gameObject.SetActive(false);
                break;
        }
    }
}
