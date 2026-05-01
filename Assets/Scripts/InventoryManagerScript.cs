using Unity.VisualScripting;
using UnityEngine;

public class InventoryManagerScript : MonoBehaviour, IInteractable
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Interact()
    {
        if (gameObject.tag == "Collectable")
        {
            Debug.Log("COLLECT");
        }
        else if (gameObject.tag == "Interactable")
        {
            Debug.Log("INTERACT");
        }
    }
}
