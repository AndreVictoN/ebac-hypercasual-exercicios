using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Lerp")]
    public float speed = 1f;
    public float lerpSpeed = 1f;
    public Transform target;
    
    [Header("Collsions")]
    public string enemyTag = "Enemy";
    public string endLine = "EndLine";

    public GameObject endScreen;

    private Vector3 _pos;
    private bool _canRun = false;

    void Update()
    {
        if(!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag(enemyTag) || other.transform.CompareTag(endLine))
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        _canRun = false;
        endScreen.SetActive(true);
    }

    public void StartToRun()
    {
        _canRun = true;
    }
}
