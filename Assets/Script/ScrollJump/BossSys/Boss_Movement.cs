using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Movement : MonoBehaviour
{
    public BossController bossController;
    public float movespeed;
    public Transform[] movepoints;
    private int currentMovePointIndex = 0;
    private int direction = 1; // 1 for forward, -1 for backward

    void Start()
    {
        if (movepoints.Length > 1)
        {
            transform.position = movepoints[0].position;
            currentMovePointIndex = 1;
        }
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (currentMovePointIndex >= 0 && currentMovePointIndex < movepoints.Length)
        {
            float step = movespeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, movepoints[currentMovePointIndex].position, step);

            if (transform.position == movepoints[currentMovePointIndex].position)
            {
                currentMovePointIndex += direction;

                if (currentMovePointIndex >= movepoints.Length)
                {
                    currentMovePointIndex = movepoints.Length - 2;
                    direction = -1;
                }
                else if (currentMovePointIndex < 0)
                {
                    currentMovePointIndex = 1;
                    direction = 1;
                }
            }
        }
    }
}
