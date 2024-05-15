using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStat : MonoBehaviour
{
    public BossController bossController;
    public void BossTakeDamage(float damageAmount)
    {
        bossController.boss_hp -= damageAmount;
    }
}
