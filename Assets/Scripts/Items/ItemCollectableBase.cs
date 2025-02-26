using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.transform.CompareTag(compareTag))
        {
            Collect(collider);
        }
    }

    protected virtual void Collect(Collider collider)
    {
        HideObject();
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        
    }
}
