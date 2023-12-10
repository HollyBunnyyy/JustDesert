using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private bool _isLocked = false;
    public bool IsLocked => _isLocked;

    public void Unlock()
    {
        _isLocked = false;
    }

    public void Lock()
    {
        _isLocked = true;
    }

    public bool OnInteract( GameObject interactingObject )
    {
        Debug.Log( "Interaction from " + interactingObject.name + " on " + gameObject.name );

        return true;
    }
}
