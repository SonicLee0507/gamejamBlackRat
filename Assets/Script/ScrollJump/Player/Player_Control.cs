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


    void Start()
    {
        player_healthBar.maxValue = player_maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        player_healthBar.value = player_hp;

        PlayerSkillSet();

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Player.transform.rotation = rotation;


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (stage == 2)
            {
                Debug.Log("Input.GetKeyDown(KeyCode.Mouse1)");
            }
            if (stage == 3)
            {
                Debug.Log("Input.GetKeyDown(KeyCode.Mouse1)");
            }
        }
        else if (Input.GetKey(KeyCode.Mouse1) & stage == 1)
        {
            Debug.Log("Input.GetKey(KeyCode.Mouse1) & stage == 1");
            if (scrollJump.jumpnumb == 0)
            {
                Debug.Log("scrollJump.jumpnumb == 0");


            }
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

}
