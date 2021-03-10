using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingInteractable : MonoBehaviour, IInteractable
{

    //Write what the interactable will do
    public void Interact(Vector3 hitPoint)
    {
        //Debug.Log("You interacted with me! at: " + Time.time);
        Inventory.collectEvent.Invoke(gameObject);
        GetComponentInChildren<ParticleSystem>().Play();
        GameObject particleSystem = transform.GetChild(0).gameObject;
        particleSystem.transform.parent = null;
        particleSystem.transform.position = hitPoint;
        Destroy(gameObject);
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
