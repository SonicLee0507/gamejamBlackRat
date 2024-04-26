using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private List<Transform> rpg_movepoint;
    [SerializeField] private int stage = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextStage();
    }

    public void MoveToNextStage()
    {
        if (Input.GetKeyDown(KeyCode.M) & stage < 3)
        {
            stage += 1;
            transform.position = rpg_movepoint[stage].position;
            return;
        }
    }

}
