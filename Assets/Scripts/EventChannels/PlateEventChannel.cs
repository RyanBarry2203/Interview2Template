using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Plate Event Channel", menuName = "GameData/ EventChannel/ PlateEventChannel")]
public class PlateEventChannel : ScriptableObject
{
    public UnityAction OnPlatePressed;
    public UnityAction OnPlateReleased;

        public void RaisePlatePressed()
        {

            OnPlatePressed?.Invoke();
            
        }
        public void RaisePlateReleased()
        {
            OnPlateReleased?.Invoke();
        }

}
