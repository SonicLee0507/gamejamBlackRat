using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Atk_Effect : MonoBehaviour
{
    private Rigidbody rg;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.AddForce(Vector3.up * 20);
        rg.AddForce(Vector3.left * 10);
    }
    private void Update()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

}
