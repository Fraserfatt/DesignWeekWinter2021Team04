using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : Menu
{
    public GameObject player;
    public void ResumeButton()
    {
        player.GetComponent<RigidbodyFirstPersonController>().enabled = true;
        MenuManager.Instance.hideMenu(menuClassifier);
    }
}
