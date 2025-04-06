using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeedUp : PowerUpBase
{
    [Header("PowerUpSpeed")]
    public float amountToSpeed = 2f;

    protected override void StartPowerUp()
    {
        base.StartPowerUp();

        PlayerController.Instance.PowerUpSpeed(amountToSpeed);
        PlayerController.Instance.SetPowerUpText("SpeedUp");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();

        PlayerController.Instance.ResetSpeed();
        PlayerController.Instance.SetPowerUpText("");
    }
}
