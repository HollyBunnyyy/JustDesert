using UnityEngine;

public class Interactable : MonoBehaviour, IInteractable
{
    public virtual bool OnInteract( GameObject interactingObject )
    {
        return true;
    }
}
