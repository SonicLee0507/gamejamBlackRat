using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl_SJ : MonoBehaviour
{
    public Player_Control player_Control;

    public float totalSpeed;
    public int stage;

    public float TimeCounter;

    [SerializeField]private GameObject LostPage;
    // Update is called once per frame
    void Update()
    {
        TimeCounting();
    }

    private void FixedUpdate()
    {
                
        if (totalSpeed < 2 & totalSpeed > 0)
        {
            totalSpeed += Time.deltaTime*0.1f;
        }
        else if (totalSpeed > 2 )
        {
            totalSpeed = 2;
        }
        else if (totalSpeed <=0)
        {
            LostPage.SetActive(true);
        }
        if(player_Control.player_hp <= 0)
        {
            LostPage.SetActive(true);
        }
    }

    public void SlowTime(float decrease)
    {
        totalSpeed -= decrease;
        Debug.Log("Slow "+ decrease + "% speed");
    }

    private void TimeCounting()
    {
        TimeCounter += Time.deltaTime * totalSpeed;
        if (TimeCounter >= 10 & TimeCounter < 20 & stage == 0)
        {
            stage = 1;
        }
        else if(TimeCounter >= 20 & TimeCounter < 30 & stage == 1)
        {
            stage = 2;
        }
        else if (TimeCounter >= 30 & TimeCounter < 120 & stage == 2)
        {
            stage = 3;
        }
        else if (TimeCounter >= 120 & stage == 3)
        {
            stage = 4;
        }
    }
}
