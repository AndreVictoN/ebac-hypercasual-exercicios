using System.Collections;
using System.Collections.Generic;
using Ebac.Core.Singleton;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class ItemsManager : Singleton<ItemsManager>
{
    [Header("Coins")]
    SOInt coins;

    public TextMeshProUGUI coinsNumber;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }
}
