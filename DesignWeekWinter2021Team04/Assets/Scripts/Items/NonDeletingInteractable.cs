using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonDeletingInteractable : MonoBehaviour, IInteractable
{
    ParticleSystem particles;
    public void Interact(GameObject player, Vector3 hitPoint)
    {
        if (tag == "Fish")
        {
            if (!player.GetComponentInChildren<Inventory>().BerryCheck())
            {
                CollectText.Instance.GetComponent<Text>().text = "Collect a berry to catch the fish";
                particles.transform.position = hitPoint;
                particles.Play();
                return;
            }
        }

        CollectText.Instance.GetComponent<Text>().text = "Collected";
        Inventory.collectEvent.Invoke(gameObject);
        particles.transform.position = hitPoint;
        particles.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
