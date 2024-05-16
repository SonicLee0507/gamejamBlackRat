using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Atk : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float player_damage;
    [SerializeField] private GameObject effect;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.right * speed*Time.deltaTime;
        if (transform.position.x > 30)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boss")
        {
            Debug.Log("HitBoss");
            other.GetComponent<BossStat>().BossTakeDamage(player_damage);
            Instantiate(effect, transform.position, Quaternion.Euler(Vector3.zero));
            Destroy(gameObject);
        }
        else if(other.tag == "Enemy")
        {
            Debug.Log("HitEnemy");
            other.GetComponent<RoadBlock>().BlockTakeDamage(player_damage);
            Instantiate(effect, transform.position, Quaternion.Euler(Vector3.zero));
            Destroy(gameObject);
        }
    }


}
