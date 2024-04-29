using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightSys : MonoBehaviour
{
    public GameControl gameControl;

    [SerializeField] public EnemData enemData1;
    [SerializeField] public PlayerData playerData;

    [SerializeField] public List<GameObject> Enems;
    [SerializeField] public List<GameObject> Players;

    [SerializeField] private List<GameObject> PlayerTargetPointPos;
    [SerializeField] private List<GameObject> EnemTargetPointPos;
    [SerializeField] private GameObject targetPoint;

    [SerializeField] public int turnSelect = 0;
    [SerializeField] public int targetSelect = 0;

    [SerializeField] public bool isPlayerTurn = true;
    [SerializeField] public bool isEnemTurn = false;

    [SerializeField] private List<GameObject> BattleEnems;

    [SerializeField] private int battleCounts = 0;

    [SerializeField] private TextMeshProUGUI dialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartBattle()
    {
        BattleEnems.Clear();

        if (gameControl.isbattle == true)
        {
            if (battleCounts == 0)
            {
                BattleEnems.Add(Enems[0]);
                Debug.Log("Add(Enems[0]");
                SelectTarget();

                dialogue.text = "You've Encounter <br>Angry Nerdy Fatty Rat!!! ";



                return;
            }
            else if (battleCounts == 1)
            {
                BattleEnems.Add(Enems[1]);
                dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
                EnemData enemData1 = BattleEnems[0].GetComponent<EnemData>();
            }
            else if (battleCounts == 2)
            {
                BattleEnems.Add(Enems[2]);
                BattleEnems.Add(Enems[3]);
                dialogue.text = "You've Encounter <br> Angry Nerdy Fatty Rat and Weirdo flea ";
            }
            else if (battleCounts == 3)
            {
                BattleEnems.Add(Enems[4]);
                dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
            }
            else if (battleCounts == 4)
            {
                BattleEnems.Add(Enems[5]);
                BattleEnems.Add(Enems[6]);
                dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
            }
            else if (battleCounts == 5)
            {
                BattleEnems.Add(Enems[7]);
                dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
            }
        }
    }

    public void EndBattle()
    {

    }


    private void SelectTarget()
    {
        targetPoint.SetActive(true);
        if (isPlayerTurn & !isEnemTurn)
        {
            turnSelect = Random.Range(0, Players.Count - 1);

            targetPoint.transform.position = PlayerTargetPointPos[turnSelect].transform.position;
            dialogue.text = "Player" + turnSelect + "'s turn";
        }
        else if(!isPlayerTurn & isEnemTurn)
        {
            turnSelect = Random.Range(0,BattleEnems.Count - 1);
            targetPoint.transform.position = EnemTargetPointPos[turnSelect].transform.position;
            dialogue.text = "Enemy" + turnSelect + "'s turn";
        }
        else { Debug.Log("Waiting"); }
    }


    public void PlayerAttack()
    {
        if (isPlayerTurn)
        {
            if (targetSelect == 0)
            {                
                EnemData enemData1 = BattleEnems[0].GetComponent<EnemData>();
                if (enemData1 == null)
                {
                    Debug.LogError("Didin't get enemData1");
                }
                enemData1.enem_hp -= 20;
                dialogue.text = "deal 20 dmg";
            }
            else if (targetSelect == 1)
            {
                enemData1.enem_hp -= 10;
                dialogue.text = "deal 10 dmg";
            }
            else if (targetSelect == 2)
            {
                enemData1.enem_hp -= 10;
                dialogue.text = "deal 10 dmg";
            }
            else if (targetSelect == 3)
            {
                enemData1.enem_hp -= 15;
                dialogue.text = "deal 15 dmg";
            }

        }
        isPlayerTurn = false;
        isEnemTurn = true;
        SelectTarget();
    }
    public void PlayerSkill()
    {
        if (isPlayerTurn)
        {

        }
        isPlayerTurn = false;
        isEnemTurn = true;
        SelectTarget();
    }

    private void EnemAttack()
    {
        if (isEnemTurn)
        {

        }
        isPlayerTurn = true;
        isEnemTurn = false;
        SelectTarget();
    }
    private void EnemSkill()
    {
        if (isEnemTurn)
        {

        }
        isPlayerTurn = true;
        isEnemTurn = false;
        SelectTarget();
    }

}
