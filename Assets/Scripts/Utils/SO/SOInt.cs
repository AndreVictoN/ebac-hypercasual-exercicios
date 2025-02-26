using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class SOInt : ScriptableObject
{
    public int value;

    void Start()
    {
        value = 0;
    }
}
