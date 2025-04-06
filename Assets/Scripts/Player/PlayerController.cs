using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{
    [Header("Lerp")]
    public float speed = 1f;
    public float lerpSpeed = 1f;
    public Transform target;
    
    [Header("Collsions")]
    public string enemyTag = "Enemy";
    public string endLine = "EndLine";

    [Header("PowerUp")]
    public TextMeshPro uiPowerUpText;
    public bool isInvincible = false;

    public GameObject endScreen;

    private Vector3 _pos;
    private bool _canRun = false;
    private Vector3 _startPosition;
    private float _currentSpeed;

    void Start()
    {
        _startPosition = transform.position;

        ResetSpeed();
        ResetInvincible();
    }

    void Update()
    {
        if(!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if((other.transform.CompareTag(enemyTag) && !isInvincible) || other.transform.CompareTag(endLine))
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

    #region PowerUps

    public void SetPowerUpText(string powerUp)
    {
        uiPowerUpText.text = powerUp;
    }

    public void PowerUpSpeed(float amountToSpeed)
    {
        _currentSpeed += amountToSpeed;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void PowerUpFloat(float amountHeight, float duration, Ease ease, float animationDuration)
    {
        transform.DOMoveY(_startPosition.y + amountHeight, animationDuration).SetEase(ease);

        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight(float animationDuration)
    {
        transform.DOMoveY(_startPosition.y, animationDuration);
    }

    public void PowerUpInvincible()
    {
        isInvincible = true;
    }

    public void ResetInvincible()
    {
        isInvincible = false;
    }

    #endregion PowerUps
}
