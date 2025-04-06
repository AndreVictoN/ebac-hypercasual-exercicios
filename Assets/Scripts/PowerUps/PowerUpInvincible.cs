using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincible : PowerUpBase
{
    protected override void StartPowerUp()
    {
        base.StartPowerUp();

        PlayerController.Instance.PowerUpInvincible();
        PlayerController.Instance.SetPowerUpText("Invincible");
    }

    protected override void EndPowerUp()
    {
        base.EndPowerUp();

        PlayerController.Instance.ResetInvincible();
        PlayerController.Instance.SetPowerUpText("");
    }
}
