using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{



    public Dialogue dialogue;
    public FightSys fightSys;
    public GameControl gameControl;
    [SerializeField] private List<Transform> rpg_movepoint;
    [SerializeField] private int stage = 0;
    [SerializeField] private int maxstage = 4;
    [SerializeField] private float moveSpeed = 1.0f; // ²¾°Ê³t«×
    [SerializeField] private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        MoveToNextStage();
        StageDetecter();
    }

    private void MoveToNextStage()
    {
        if (Input.GetKeyDown(KeyCode.M) && stage < maxstage)
        {

            if (stage < rpg_movepoint.Count)
            {
                StartCoroutine(MoveToPosition(rpg_movepoint[stage].position));
            }
        }



    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void StageDetecter()
    {
        if (transform.position == rpg_movepoint[0].position || transform.position == rpg_movepoint[1].position || transform.position == rpg_movepoint[2].position ||
            transform.position == rpg_movepoint[3].position || transform.position == rpg_movepoint[4].position || 
            transform.position == rpg_movepoint[5].position || transform.position == rpg_movepoint[6].position ||
            transform.position == rpg_movepoint[7].position || transform.position == rpg_movepoint[8].position || transform.position == rpg_movepoint[9].position   )
        {
            GameStageChanger();
        }
    }

    public void GameStageChanger()
    {
        if (gameControl.isbattle ==false & stage == 0)
        {
            stage += 1;
            gameControl.isStory = true;
            Debug.Log("isStory");
            dialogue.ReadStory();
            Debug.Log("stage1");
        }
        else if (transform.position == rpg_movepoint[1].position & gameControl.isbattle == false & stage == 1)
        {
            stage += 1;
            gameControl.isbattle = true;
            Debug.Log("isbattle");
            fightSys.StartBattle();
        }
        else if (transform.position == rpg_movepoint[2].position & gameControl.isbattle == false & stage == 2)
        {
            stage += 1;
            gameControl.isStory = true;
            Debug.Log("isStory");
            dialogue.ReadStory();
            Debug.Log("stage1");
        }
        else if (transform.position == rpg_movepoint[3].position & gameControl.isbattle == false & stage == 3)
        {
            stage += 1;
            gameControl.isStory = true;
            Debug.Log("isStory");
            dialogue.ReadStory();
            Debug.Log("stage1");
        }
        else if (transform.position == rpg_movepoint[4].position & gameControl.isbattle == false & stage == 4)
        {
            stage += 1;
            gameControl.isbattle = true;
            Debug.Log("isbattle");
            fightSys.StartBattle();
        }
        else if (transform.position == rpg_movepoint[5].position & gameControl.isbattle == false & stage == 5)
        {
            stage += 1;
            gameControl.isStory = true;
            Debug.Log("isStory");
            dialogue.ReadStory();
            Debug.Log("stage1");
        }
        else if (transform.position == rpg_movepoint[6].position & gameControl.isbattle == false & stage == 6)
        {
            stage += 1;
            gameControl.isbattle = true;
            Debug.Log("isbattle");
            fightSys.StartBattle();
        }
        else if (transform.position == rpg_movepoint[7].position & gameControl.isbattle == false & stage == 7)
        {
            stage += 1;
            gameControl.isStory = true;
            Debug.Log("isStory");
            dialogue.ReadStory();
            Debug.Log("stage1");
        }
        else if (transform.position == rpg_movepoint[8].position & gameControl.isbattle == false & stage == 8)
        {
            stage += 1;
            gameControl.isStory = true;
            Debug.Log("isStory");
            dialogue.ReadStory();
            Debug.Log("stage1");
        }
        else if (transform.position == rpg_movepoint[9].position & gameControl.isbattle == false & stage == 9)
        {
            stage += 1;
            gameControl.isbattle = true;
            Debug.Log("isbattle");
            fightSys.StartBattle();
        }
        else
        {
            //Debug.LogError("Cannotenter");
        }
    }

}
