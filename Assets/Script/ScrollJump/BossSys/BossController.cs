using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Boss_Movement boss_Movement;
    [SerializeField] private int stage;
    public float movespeed;
    //[SerializeField] public Animator anim;
    [SerializeField] public Animator boss_anim;

    [SerializeField] public Slider boss_healthBar;
    [SerializeField] public float boss_hp;
    [SerializeField] public int boss_maxhp;

    public Transform[] atkpoints;
    // Start is called before the first frame update
    void Start()
    {
        boss_healthBar.maxValue = boss_maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        boss_healthBar.value = boss_hp;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            boss_Movement.canMove = false;
            
            //anim.Play("atk_1");
            //anim.enabled = !anim.enabled;
            boss_anim.Play("atk_1");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            boss_Movement.canMove = false;
            //anim.Play("atk_2");
            //anim.enabled = !anim.enabled;
            boss_anim.Play("atk_2");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            boss_Movement.canMove = false;
            //anim.Play("atk_3");
            //anim.enabled = !anim.enabled;
            boss_anim.Play("atk_3");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            boss_Movement.canMove = false;
            //anim.Play("atk_4");
            //anim.enabled = !anim.enabled;
            boss_anim.Play("atk_4");
        }

    }
}
