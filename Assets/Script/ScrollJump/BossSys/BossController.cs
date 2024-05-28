
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Boss_Movement boss_Movement;
    [SerializeField] private int stage;
    public float movespeed;
    //[SerializeField] public Animator anim;
    [SerializeField] public Animator boss_anim;
    [SerializeField] public Animator boss2_anim;

    public GameObject boss;

    public GameObject boss2;

    [SerializeField] public Slider boss_healthBar;
    [SerializeField] public GameObject healthBar;
    [SerializeField] public float boss_hp;
    [SerializeField] public int boss_maxhp;
    public float boss_AtkTime;
    public float boss_MaxAtkTime;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetActive(true);
        boss_healthBar.maxValue = boss_maxhp;
        boss_AtkTime = boss_MaxAtkTime;
    }

    // Update is called once per frame
    void Update()
    {
        boss_healthBar.value = boss_hp;

        if (Input.GetKeyDown(KeyCode.P))
        {
            boss_hp = 0;
        }
        if (boss_AtkTime > 0)
        {
            boss_AtkTime -= Time.deltaTime;
        }
        else if (boss_AtkTime <= 0)
        {
            boss_AtkTime = boss_MaxAtkTime;
            if (boss != null)
            {
            boss_anim.Play("atk_" + Random.Range(1, 4));
            }
            if (boss2 != null)
            {
                boss2_anim.Play("atk_" + Random.Range(1, 4));
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            boss_Movement.canMove = false;
            if (boss != null)
            {
                boss_anim.Play("atk_1");
            }
            if (boss2 != null)
            {
                boss2_anim.Play("atk_1");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            boss_Movement.canMove = false;
            if (boss != null)
            {
                boss_anim.Play("atk_2");
            }
            if (boss2 != null)
            {
                boss2_anim.Play("atk_2");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            boss_Movement.canMove = false;
            if (boss != null)
            {
                boss_anim.Play("atk_3");
            }
            if (boss2 != null)
            {
                boss2_anim.Play("atk_3");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            if (boss != null)
            {
                boss_anim.Play("atk_4");
            }
            if (boss2 != null)
            {
                boss2_anim.Play("atk_4");
            }
        }

        if (boss_hp <=0)
        {
            if (boss != null)
            {
                boss_anim.Play("Trans");
                Destroy(boss, 5);
                Invoke("NullifyBoss", 5);
            }
            if(boss == null& stage == 1)
            {
                stage = 2;
                boss_hp = boss_maxhp;
                boss2.SetActive(true);
            }
            if (boss2 != null& stage == 3)
            {
                boss2_anim.Play("Trans");
                Destroy(boss2, 5);
            }
        }

        if (stage == 2)
        {
            boss2.SetActive(true);
            boss_hp = 400;
            stage = 3;
        }

    }
    private void NullifyBoss()
    {
        boss = null;
    }

}
