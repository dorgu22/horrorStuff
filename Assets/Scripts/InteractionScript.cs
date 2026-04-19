using UnityEngine;
using UnityEngine.EventSystems;

public interface IInteractable
{
    public void Interact();
}

public class InteractionScript : MonoBehaviour
{
    public Transform InteractionSource;
    public float InteractionRange;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractionSource.position, InteractionSource.forward);

            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractionRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactionObject))
                {
                    interactionObject.Interact();
                }
            }
        }
        
    }
}