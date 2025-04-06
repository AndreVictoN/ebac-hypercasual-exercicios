using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFloat : PowerUpBase
{
    [Header("PowerUpFloat")]
    public float amountHeight = 2f;
    public float animationDuration = .1f;
    public DG.Tweening.Ease ease = DG.Tweening.Ease.OutBack;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();

        PlayerController.Instance.PowerUpFloat(amountHeight, powerUpDuration, ease, animationDuration);
        PlayerController.Instance.SetPowerUpText("Floating");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();

        PlayerController.Instance.ResetHeight(animationDuration);
        PlayerController.Instance.SetPowerUpText("");
    }
}
