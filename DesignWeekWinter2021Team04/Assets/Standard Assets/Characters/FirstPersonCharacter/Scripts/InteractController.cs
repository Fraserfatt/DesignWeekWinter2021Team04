using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractController : MonoBehaviour
{


    [SerializeField]
    float interactionDistance = 5;

    [SerializeField]
    GameObject interactTextPrompt;

    Camera cameraComponent;

    GameObject currentObject;
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        #region original raycast code in this region
        //if (Physics.Raycast(cameraComponent.transform.position, cameraComponent.transform.forward, out hit, interactionDistance, LayerMask.GetMask("Interactable")))
        //{
        //    Debug.Log("Highlighting " + hit.collider.name + " at time: " + Time.time);
        //    interactTextPrompt.SetActive(true);
        //    interactTextPrompt.transform.position = cameraComponent.WorldToScreenPoint(hit.point);
        //}
        //else
        //{
        //    currentObject = null;
        //    Debug.Log("Currently not highlighting anything at time: " + Time.time);
        //    interactTextPrompt.SetActive(false);
        //}
        #endregion

        if (interactTextPrompt != null)
        {
            //Current cast to check for interaction.  If true, collects current object and highlights via UI
            if (Physics.SphereCast(cameraComponent.transform.position, 0.5f, cameraComponent.transform.forward, out hit, interactionDistance, LayerMask.GetMask("Interactable")))
            {
                interactTextPrompt.SetActive(true);
                //Debug.Log("Highlighting " + hit.collider.name + " at time: " + Time.time);
                interactTextPrompt.transform.position = cameraComponent.WorldToScreenPoint(hit.point);
                currentObject = hit.transform.gameObject;
            }
            else
            {
                interactTextPrompt.SetActive(false);
                //Debug.Log("Currently not highlighting anything at time: " + Time.time);
                currentObject = null;
            }

            if (currentObject != null && Input.GetKeyDown(KeyCode.E))
            {
                currentObject.GetComponent<IInteractable>().Interact();
            }
        }
    }
}
