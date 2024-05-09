using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;


public class FightSys : MonoBehaviour
{
    public GameControl gameControl;

    [SerializeField] public EnemData enemData1;
    [SerializeField] public EnemData enemData2;
    [SerializeField] public PlayerData playerData;
    [SerializeField] public PlayerControl playerControl;

    [SerializeField] public List<GameObject> Enems;
    [SerializeField] public List<GameObject> Players;
    [SerializeField] public List<GameObject> BattleEnems;
    [SerializeField] private List<GameObject> PlayerTargetPointPos;
    [SerializeField] private List<GameObject> EnemTargetPointPos;

    [SerializeField] private GameObject targetPoint;

    [SerializeField] public int turnSelect = 0;
    [SerializeField] public int targetSelect = 0;

    [SerializeField] public bool isPlayerTurn = true;
    [SerializeField] public bool isEnemTurn = false;
    [SerializeField] private bool isWaiting = false;

    [SerializeField] public int player_attack;

    [SerializeField] private int battleCounts = 0;



    [SerializeField] private TextMeshProUGUI dialogue;
    [SerializeField] private List<AudioSource> fight_sfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Waiting();

    }

    public void StartBattle()
    {
        isPlayerTurn = true;
        isEnemTurn = false;
        BattleEnems.Clear();

        if (gameControl.isbattle == true)
        {
            switch (battleCounts)
            {
                case 0:
                    BattleEnems.Add(Enems[0]);
                    Debug.Log("Add(Enems[0]");
                    SelectTurn();
                    dialogue.text = "You've Encounter <br>Angry Nerdy Fatty Rat!!! ";
                    break;
                case 1:
                    BattleEnems.Add(Enems[1]);
                    BattleEnems.Add(Enems[2]);
                    dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
                    break;
                case 2:
                    BattleEnems.Add(Enems[3]);
                    BattleEnems.Add(Enems[4]);
                    dialogue.text = "You've Encounter <br> Angry Nerdy Fatty Rat and Weirdo flea ";
                    break;
                case 3:
                    BattleEnems.Add(Enems[5]);
                    BattleEnems.Add(Enems[6]);
                    dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
                    break;
                case 4:
                    BattleEnems.Add(Enems[7]);
                    dialogue.text = "You've Encounter <br> Angry Li ";
                    break;

            }
            //if (battleCounts == 0)
            //{
            //    BattleEnems.Add(Enems[0]);
            //    Debug.Log("Add(Enems[0]");
            //    SelectTurn();
            //    dialogue.text = "You've Encounter <br>Angry Nerdy Fatty Rat!!! ";
            //    return;
            //}

            //else if (battleCounts == 1)
            //{
            //    BattleEnems.Add(Enems[1]);
            //    BattleEnems.Add(Enems[2]);
            //    dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
            //}

            //else if (battleCounts == 2)
            //{

            //    BattleEnems.Add(Enems[3]);
            //    BattleEnems.Add(Enems[4]);
            //    dialogue.text = "You've Encounter <br> Angry Nerdy Fatty Rat and Weirdo flea ";
            //}

            //else if (battleCounts == 3)
            //{
            //    BattleEnems.Add(Enems[5]);
            //    BattleEnems.Add(Enems[6]);
            //    dialogue.text = "You've Encounter <br> 2 Angry Nerdy Fatty Rat ";
            //}

            //else if (battleCounts == 4)
            //{

            //    BattleEnems.Add(Enems[7]);
            //    dialogue.text = "You've Encounter <br> Angry Li ";
            //}
        }
    }
    public void EndBattle()
    {
        if (BattleEnems.Count == 0 )
        {
            Debug.Log("End Battle");
            gameControl.isbattle = false;
            battleCounts += 1;
            playerControl.MoveToNextStage();
            playerControl.GameStageChanger();

        }
    }

    private void SelectTurn()
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
            turnSelect = Random.Range(0,BattleEnems.Count );
            targetPoint.transform.position = EnemTargetPointPos[turnSelect].transform.position;
            dialogue.text = "Enemy" + turnSelect + "'s turn";
        }
        else { Debug.Log("Waiting"); }
    }
    public void PlayerAttack()
    {
        if (isPlayerTurn & !isWaiting)
        {
            if (turnSelect == 0)
            {
                //find data
                player_attack = 20;
                dialogue.text = "deal 20 dmg";
            }
            else if (turnSelect == 1)
            {
                //find data
                player_attack = 10;
                dialogue.text = "deal 10 dmg";
            }
            else if (turnSelect == 2)
            {
                //find data
                player_attack = 10;
                dialogue.text = "deal 10 dmg";
            }
            else if (turnSelect == 3)
            {
                //find data
                player_attack = 15;
                dialogue.text = "deal 15 dmg";
            }

        }

        isPlayerTurn = false;
        isEnemTurn = true;
        SelectTurn();
        EndBattle();
    }

    public void AttackTarget1()
    {
        if (BattleEnems[0] != null & isPlayerTurn & !isWaiting)
        {
            EnemData enemData1 = BattleEnems[0].GetComponent<EnemData>();
            enemData1.enem_hp -= player_attack;
            isPlayerTurn = false;
            isEnemTurn = true;
            isWaiting = true;
            SelectTurn();
            EndBattle();
        }
    }
    public void AttackTarget2()
    {
        if (BattleEnems[1] != null& isPlayerTurn & !isWaiting)
        {
            EnemData enemData2 = BattleEnems[1].GetComponent<EnemData>();
        enemData2.enem_hp -= player_attack;
        isPlayerTurn = false;
        isEnemTurn = true;
        isWaiting = true;
        SelectTurn();
        EndBattle();
        }
        else if (BattleEnems[0] != null & isPlayerTurn & !isWaiting)
        {
            EnemData enemData1 = BattleEnems[0].GetComponent<EnemData>();
            enemData1.enem_hp -= player_attack;
            isPlayerTurn = false;
            isEnemTurn = true;
            isWaiting = true;
            SelectTurn();
            EndBattle();
        }
    }
    public void PlayerSkill()
    {
        if (isPlayerTurn & !isWaiting)
        {
            if (turnSelect == 0)
            {
                playerData.player_hp += 20;
                dialogue.text = "+ 20 hp";
                isWaiting = true;
            }
            else if (turnSelect == 1)
            {
                playerData.player_hp += 20;
                dialogue.text = "+ 20 hp";
                isWaiting = true;
            }
            else if (turnSelect == 2)
            {
                playerData.player_hp += 20;
                dialogue.text = "+ 20 hp";
                isWaiting = true;
            }
            else if (turnSelect == 3)
            {
                playerData.player_hp += 20;
                dialogue.text = "+ 20 hp";
                isWaiting = true;
            }
        }
        isPlayerTurn = false;
        isEnemTurn = true;
        isWaiting = true;
        SelectTurn();
        EndBattle();
    }
    private void EnemAttack()
    {
        if (isEnemTurn & !isWaiting)
        {
            if (turnSelect == 0)
            {
                EnemData enemData1 = BattleEnems[0].GetComponent<EnemData>();

                playerData.player_hp -= enemData1.enem_attack;
                dialogue.text = "deal"+ enemData1.enem_attack + "dmg";
                isWaiting = true;
            }
            else if (turnSelect == 1)
            {
                EnemData enemData2 = BattleEnems[1].GetComponent<EnemData>();
                //find data
                playerData.player_hp -= enemData2.enem_attack;
                dialogue.text = "deal" + enemData2.enem_attack + "dmg";
                isWaiting = true;
            }

        }
        isPlayerTurn = true;
        isEnemTurn = false;
        isWaiting = true;
        //SelectTarget();
    }
    private void EnemSkill()
    {
        if (isEnemTurn & !isWaiting)
        {
            if (turnSelect == 0)
            {
                //find data
                EnemData enemData1 = BattleEnems[0].GetComponent<EnemData>();
                if (enemData1 == null)
                {
                    Debug.LogError("Didin't get enemData1");
                }
                //find data
                playerData.player_hp -= enemData1.enem_attack;
                dialogue.text = "deal" + enemData1.enem_attack + "dmg";
                isWaiting = true;
            }
            else if (turnSelect == 1)
            {
                //find data
                EnemData enemData2 = BattleEnems[1].GetComponent<EnemData>();
                if (enemData2 == null)
                {
                    Debug.LogError("Didin't get enemData1");
                }
                //find data
                playerData.player_hp -= enemData2.enem_attack;
                dialogue.text = "deal" + enemData2.enem_attack + "dmg";
                isWaiting = true;
            }
        }
        isPlayerTurn = true;
        isEnemTurn = false;
        isWaiting = true;
        //SelectTarget();
    }
    private void Waiting()
    {
        if (isWaiting)
        {

            if (Input.anyKeyDown & !isPlayerTurn)
            {
            isWaiting = false;
                SelectTurn();
                EnemAttack();
            }
            if (Input.anyKeyDown & isPlayerTurn)
            {
                isWaiting = false;
                SelectTurn();
            }


        }
    }


}
