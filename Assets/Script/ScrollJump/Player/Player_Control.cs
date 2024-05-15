
using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    [SerializeField] public ScrollJump scrollJump;
    [SerializeField] private int stage;
    //[SerializeField] public Animator anim;
    public Animator player_anim;

    public Slider player_healthBar;
    public float player_hp;
    public int player_maxhp;

    [SerializeField] private Image player_stage_image;
    [SerializeField] private Sprite[] player_stage_spritelist;

    public GameObject Player;
    public GameObject Arrow;

    public Transform firepoint;


    void Start()
    {
        player_healthBar.maxValue = player_maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        player_healthBar.value = player_hp;

        PlayerSkillSet();


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (stage == 2)
            {
                Debug.Log("stage == 2");

            }
            if (stage == 3)
            {
                Debug.Log("stage == 3");
                Instantiate(Arrow, firepoint.position, Quaternion.AngleAxis(0, Vector3.forward));

            }
        }
        else if (Input.GetKey(KeyCode.Mouse1) & stage == 1)
        {
            Debug.Log("Input.GetKey(KeyCode.Mouse1) & stage == 1");
            if (scrollJump.jumpnumb == 0)
            {
                Debug.Log("scrollJump.jumpnumb == 0");
                Rotate();
            }
        }

        if (scrollJump.jumpnumb == 1)
        {
            Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

    }

    private void PlayerSkillSet()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stage = 1;
            player_stage_image.sprite = player_stage_spritelist[0];
            player_anim.Play("stage_1");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            stage = 2;
            player_stage_image.sprite = player_stage_spritelist[1];
            player_anim.Play("stage_2");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            stage = 3;
            player_stage_image.sprite = player_stage_spritelist[2];
            player_anim.Play("stage_3");
        }
    }

    private void Rotate()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        Player.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void PlayerTakeDamage(float damageAmount)
    {
        player_hp -= damageAmount;
    }
}
