using UnityEngine;

public class UncrouchingTriggerScript : MonoBehaviour
{
    [SerializeField] private FirstPersonController _firstPersonController;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _firstPersonController.enableCrouch = false;
            Debug.Log("ENTER");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _firstPersonController.enableCrouch = true;
        Debug.Log("EXIT");
    }
}