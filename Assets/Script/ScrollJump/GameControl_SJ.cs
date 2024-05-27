using UnityEngine.UI;
using UnityEngine;

public class GameControl_SJ : MonoBehaviour
{
    public Player_Control player_Control;
    public StopGame stop;

    public float totalSpeed;
    public int stage;

    public float TimeCounter;
    public float TimeWin;

    [SerializeField]private GameObject LostPage;

    [SerializeField] private GameObject TutorPage1;
    [SerializeField] private GameObject TutorPage2;
    [SerializeField] private GameObject TutorPage3;

    [SerializeField] private GameObject SkyBlock;
    [SerializeField] private GameObject Boss;
    public Slider TimeBar;
    public Slider SpeedBar;
    // Update is called once per frame

    private void Start()
    {
        TimeBar.maxValue = TimeWin;
        SpeedBar.maxValue = 3;
    }
    void Update()
    {
        TimeCounting();
        TimeBar.value = TimeCounter;
        SpeedBar.value = totalSpeed;
    }

    private void FixedUpdate()
    {
                
        if (totalSpeed < 3 & totalSpeed > 0)
        {
            totalSpeed += Time.deltaTime*0.2f;
        }
        else if (totalSpeed > 3 )
        {
            totalSpeed = 3;
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
            TutorPage1.SetActive(true);
            SkyBlock.SetActive(true);
            stop.StopDeGame();
            stage = 1;
        }
        else if (TimeCounter >= 15 & TimeCounter < 16)
        {
            //TutorPage1.SetActive(true);
            //SkyBlock.SetActive(true);
            //stop.StopDeGame();
        }
        else if(TimeCounter >= 20 & TimeCounter < 30 & stage == 1)
        {
            TutorPage2.SetActive(true);
            stop.StopDeGame();
            stage = 2;
        }
        else if (TimeCounter == 20)
        {
            //TutorPage2.SetActive(true);
            //stop.StopDeGame();
        }
        else if (TimeCounter >= 30 & TimeCounter < 60 & stage == 2)
        {
            TutorPage3.SetActive(true);
            stop.StopDeGame();
            stage = 3;
        }
        else if (TimeCounter >= 60 & stage == 3)
        {
            Boss.SetActive(true);
            stage = 4;
        }
    }
}
