using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[CreateAssetMenu]
public class SOFloat : ScriptableObject
{
    public float value;
    
    void Start()
    {
        value = 0f;
    }
}
