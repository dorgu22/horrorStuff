using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManagerScript : MonoBehaviour, IInteractable
{
    private static List<string> _inventoryObjects = new List<string>();

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
            //switch(gameObject.name)
            //{
            //    case "TEST":
            //        Debug.Log("1488");
            //        break;
            //    default:
            //        break;
            //}

            gameObject.SetActive(false);
            _inventoryObjects.Add(gameObject.name);
        }
        else if (gameObject.tag == "Interactable")
        {
            switch(gameObject.name)
            {
                case "SecondKitchenDoorInteractable":
                    DoorInteraction();
                    break;
                case "SecondHallwayDoorInteractable":
                    DoorInteraction();
                    break;
                case "ShowerDoorInteractable":
                    DoorInteraction();
                    break;
                default:
                    break;
            }
        }
    }

    private void DoorInteraction()
    {
        if (_inventoryObjects.Contains($"{gameObject.name}Key"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            _inventoryObjects.Remove($"{gameObject.name}Key");
            Debug.Log($"{gameObject.name} открылась");
        }
        else
        {
            Debug.Log("нет ключа");
        }
    }
}
