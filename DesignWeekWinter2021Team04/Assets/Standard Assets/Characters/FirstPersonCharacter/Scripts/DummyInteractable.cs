using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyInteractable : MonoBehaviour, IInteractable
{

    //Write what the interactable will do
    public void Interact()
    {
        Debug.Log("You interacted with me! at: " + Time.time);
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
