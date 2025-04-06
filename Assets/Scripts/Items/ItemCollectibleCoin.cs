using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleCoin : ItemCollectibleBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemsManager.Instance.AddCoins();
    }
}
