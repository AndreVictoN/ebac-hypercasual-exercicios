using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOString : ScriptableObject
{
    public string str;

    void Start()
    {
        str = null;
    }
}
