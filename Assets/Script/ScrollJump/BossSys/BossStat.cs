
using UnityEngine;

public class BossStat : MonoBehaviour
{
    public BossController bossController;
    public void BossTakeDamage(float damageAmount)
    {
        bossController.boss_hp -= damageAmount;
    }
}
