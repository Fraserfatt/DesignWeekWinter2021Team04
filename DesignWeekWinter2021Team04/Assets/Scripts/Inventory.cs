using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class CollectEvent : UnityEvent<GameObject> { }

public class Inventory : MonoBehaviour
{

    public static CollectEvent collectEvent = new CollectEvent();

    Image[] inventoryObjects;

    bool[] objectCheck;
    // Start is called before the first frame update
    void Start()
    {
        inventoryObjects = GetComponentsInChildren<Image>();
        collectEvent.AddListener(EnableItem);
        objectCheck = new bool[inventoryObjects.Length];
    }

    // Update is called once per frame
    void Update()
    {
        //check button
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (CompleteCheck())
            {
                Debug.Log("YOU ARE COMPLETE! at: " + Time.time);
            }
            else
            {
                Debug.Log("YOU ARE NOT COMPLETE! at: " + Time.time);
            }
        }
    }

    void EnableItem(GameObject item)
    {
        Debug.Log(item.tag);
        switch (item.tag)
        {
            case "Fish":
                inventoryObjects[0].enabled = true;
                objectCheck[0] = true;
                break;

            case "Bucket":
                inventoryObjects[1].enabled = true;
                objectCheck[1] = true;
                break;

            case "Berries":
                inventoryObjects[2].enabled = true;
                objectCheck[2] = true;
                break;

            case "Wood":
                inventoryObjects[3].enabled = true;
                objectCheck[3] = true;
                break;

            case "Herbs":
                inventoryObjects[4].enabled = true;
                objectCheck[4] = true;
                break;

            case "Dummy Interactable":
                inventoryObjects[4].enabled = true;
                objectCheck[4] = true;
                break;

            default:
                break;
                
        }
    }

    public bool CompleteCheck()
    {
        for (int i = 0; i<objectCheck.Length; i++)
        {
            if (!objectCheck[i])
            {
                //Nope!
                return false;
            }
        }
        //else, if you don't return, it must all be done
        return true;
    }

    public bool FireCheck()
    {
        if (!(objectCheck[0] && objectCheck[1] && objectCheck[3]))
        {
            return false;
        }
        objectCheck[0] = false;
        inventoryObjects[0].enabled = false;

        objectCheck[1] = false;
        inventoryObjects[1].enabled = false;

        objectCheck[3] = false;
        inventoryObjects[3].enabled = false;

        return true;
    }

    public bool BerryCheck()
    {
        if (!objectCheck[2])
        {
            return false;
        }
        objectCheck[2] = false;
        inventoryObjects[2].enabled = false;
        return true;
    }
}
