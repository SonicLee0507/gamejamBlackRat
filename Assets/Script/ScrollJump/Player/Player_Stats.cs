using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats : MonoBehaviour
{
    public CameraControl cameraControl;
    public Player_Control player_Control;
    public GameControl_SJ gameControl;
    public void PlayerTakeDamage(float damageAmount)
    {
        if (player_Control.isBlock)
        {
            player_Control.HitEffect.SetActive(true);
            Instantiate(player_Control.HitEffect, transform.position, Quaternion.AngleAxis(0, Vector3.forward));
        }
        else { player_Control.player_hp -= damageAmount; }

        cameraControl.PlayerShakeAnimation();
        gameControl.SlowTime(damageAmount*0.05f);
    }
}
