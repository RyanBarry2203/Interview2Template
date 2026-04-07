using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractible
{
    public void Interact(GameObject interactor);
    public bool CanInteract(GameObject interactor);
}
