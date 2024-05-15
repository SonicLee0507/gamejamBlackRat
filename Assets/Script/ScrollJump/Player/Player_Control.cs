using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    [SerializeField] public ScrollJump scrollJump;
    [SerializeField] private int stage;
    //[SerializeField] public Animator anim;
    [SerializeField] public Animator player_anim;

    [SerializeField] public Slider player_healthBar;
    [SerializeField] public float player_hp;
    [SerializeField] public int player_maxhp;

    [SerializeField] private Image player_stage_image;
    [SerializeField] private Sprite[] player_stage_spritelist;

    [SerializeField] public GameObject Player;

    [SerializeField] public Transform[] firepoint;


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
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            stage = 2;
            player_stage_image.sprite = player_stage_spritelist[1];
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            stage = 3;
            player_stage_image.sprite = player_stage_spritelist[2];
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
}
