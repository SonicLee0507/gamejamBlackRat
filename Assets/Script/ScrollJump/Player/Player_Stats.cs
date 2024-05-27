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
            //player_Control.HitEffect.SetActive(true);
            Instantiate(player_Control.HitEffect, transform.position, Quaternion.AngleAxis(0, Vector3.forward));
            Time.timeScale = 0.3f;
            gameControl.SlowTime(damageAmount * 0.05f);
            //player_Control.HitEffect.SetActive(false);
        }
        else if (player_Control.isCaptureing)
        {
            player_Control.player_hp -= damageAmount;
            gameControl.totalSpeed = 2.5f;
        }
        else 
        {
            player_Control.player_hp -= damageAmount;
            gameControl.SlowTime(damageAmount * 0.05f);
        }

        cameraControl.PlayerShakeAnimation();
    }

    public void PlayerHeal(float healAmount)
    {
        player_Control.player_hp += healAmount;
    }
}
