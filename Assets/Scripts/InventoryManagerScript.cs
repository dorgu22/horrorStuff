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
            switch(gameObject.name)
            {
                case "TEST":
                    Debug.Log("1488");
                    break;
                default:
                    break;
            }
        }
        else if (gameObject.tag == "Interactable")
        {
            
        }
    }
}
