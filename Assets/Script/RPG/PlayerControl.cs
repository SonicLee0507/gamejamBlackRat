using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
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
    }

    private void MoveToNextStage()
    {
        if (Input.GetKeyDown(KeyCode.M) && stage < maxstage)
        {
            stage += 1;
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

}
