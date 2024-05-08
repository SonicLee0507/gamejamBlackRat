using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Control : MonoBehaviour
{
    [SerializeField] private int stage;
    //[SerializeField] public Animator anim;
    [SerializeField] public Animator player_anim;

    [SerializeField] public Slider player_healthBar;
    [SerializeField] public float player_hp;
    [SerializeField] public int player_maxhp;
    void Start()
    {
        player_healthBar.maxValue = player_maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        player_healthBar.value = player_hp;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            stage = 1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            stage = 2;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            stage = 3;
        }
    }
}
