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

    // Start is called before the first frame update
    void Start()
    {
        inventoryObjects = GetComponentsInChildren<Image>();
        collectEvent.AddListener(EnableItem);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnableItem(GameObject item)
    {
        Debug.Log(item.name);
        switch (item.name)
        {
            case "Fish":
                inventoryObjects[0].enabled = true;
                break;

            case "Bucket":
                inventoryObjects[1].enabled = true;
                break;

            case "Fishing Rod":
                inventoryObjects[2].enabled = true;
                break;

            case "Wood":
                inventoryObjects[3].enabled = true;
                break;

            case "Dummy Interactable":
                inventoryObjects[0].enabled = true;
                break;

            default:
                break;
                
        }
    }
}
