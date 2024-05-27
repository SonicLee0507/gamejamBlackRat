
using UnityEngine;

public class BossStat : MonoBehaviour
{
    public BossController bossController;
    public void BossTakeDamage(float damageAmount)
    {
        bossController.boss_hp -= damageAmount;
        if (bossController.boss != null)
        {
        bossController.boss_anim.Play("Hitted");    
        }
        else {bossController.boss2_anim.Play("Hitted"); }
        
    }
}
