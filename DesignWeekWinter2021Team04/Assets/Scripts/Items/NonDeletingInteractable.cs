using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonDeletingInteractable : MonoBehaviour, IInteractable
{

    public void Interact(Vector3 hitPoint)
    {
        Inventory.collectEvent.Invoke(gameObject);
        GetComponentInChildren<ParticleSystem>().transform.position = hitPoint;
        GetComponentInChildren<ParticleSystem>().Play();
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
