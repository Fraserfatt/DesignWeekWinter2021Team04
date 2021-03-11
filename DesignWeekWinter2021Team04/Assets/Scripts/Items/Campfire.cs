using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Campfire : MonoBehaviour, IInteractable
{

    public void Interact(GameObject player, Vector3 hitPoint)
    {
        if (player.GetComponentInChildren<Inventory>().FireCheck())
        {
            CollectText.Instance.GetComponent<Text>().text = "Collected";
            GetComponentsInChildren<ParticleSystem>()[0].Play();
            GetComponentsInChildren<ParticleSystem>()[1].Play();
            GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            CollectText.Instance.GetComponent<Text>().text = "Collect wood, a fish, and bucket";
            GetComponentsInChildren<ParticleSystem>()[1].Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
