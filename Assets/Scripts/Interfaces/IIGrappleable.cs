using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIGrappleable
{
    public void Grapple(GameObject grappler, RaycastHit targetPos);
    public bool CanGrapple(GameObject grappler);
}
