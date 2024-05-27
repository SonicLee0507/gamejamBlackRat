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

    public bool canMove = true;
    public bool atkMove = true;
    public bool hyperArmor = false;
    public Transform[] atkPoint;
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
        if (canMove)
        {
          Movement();
        }
        if (atkMove)
        {
            Atk_Movement();
        }
    }

    public void Movement()
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

    public void Atk_Movement()
    {
        transform.position = atkPoint[Random.Range(0, atkPoint.Length)].position;
    }
}
