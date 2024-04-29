using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] public int player_hp;

    [SerializeField] public int player_maxhp;


    [SerializeField] public Slider player_healthBar;
    // Start is called before the first frame update
    void Start()
    {
        player_healthBar.maxValue = player_maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        player_healthBar.value = player_hp;
    }
}
