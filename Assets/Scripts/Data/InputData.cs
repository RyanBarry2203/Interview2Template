using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputData : ScriptableObject
{
    private static InputData _instance;
    private static Dictionary<string, InputData>

    public static InputData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<InputData>("InputData");
            }
            return _instance;
        }
    }


}
