using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSys : MonoBehaviour
{
    public GameControl gameControl;

    [SerializeField] public List<GameObject> Enems;
    [SerializeField] public List<GameObject> Players;

    [SerializeField] private List<GameObject> TargetPointPos;
    [SerializeField] private GameObject targetPoint;

    [SerializeField] public int targetSelect = 0;

    [SerializeField] public bool isPlayerTurn = true;

    [SerializeField] private List<GameObject> BattleEnems;

    [SerializeField] private int battleCounts = 0;
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

        if (gameControl.isbattle)
        {
            if (battleCounts == 0)
            {
                BattleEnems.Add(Enems[0]);

            }
            else if (battleCounts == 1)
            {
                BattleEnems.Add(Enems[1]);
            }
            else if (battleCounts == 2)
            {
                BattleEnems.Add(Enems[2]);
                BattleEnems.Add(Enems[3]);
            }
            else if (battleCounts == 3)
            {
                BattleEnems.Add(Enems[4]);
            }
            else if (battleCounts == 4)
            {
                BattleEnems.Add(Enems[5]);
                BattleEnems.Add(Enems[6]);
            }
            else if (battleCounts == 5)
            {
                BattleEnems.Add(Enems[7]);
            }
        }
    }

    public void EndBattle()
    {

    }


    private void SelectTarget()
    {
        if (isPlayerTurn)
        {
           targetSelect = Random.Range(0, Players.Count - 1);
            isPlayerTurn = false;

            targetPoint.transform.position = TargetPointPos[targetSelect].transform.position;
        }
        else
        {
            targetSelect = Random.Range(0,BattleEnems.Count - 1);
            isPlayerTurn = true;
            targetPoint.transform.position = TargetPointPos[targetSelect].transform.position;
        }
    }


    private void PlayerAttack()
    {

    }
    private void PlayerSkill()
    {

    }

    private void EnemAttack()
    {

    }
    private void EnemSkill()
    {

    }

}
