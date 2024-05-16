using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Block_damage;
    [SerializeField] public float block_hp;

    [SerializeField] private Rigidbody rig;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-transform.right*speed*Time.deltaTime);
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PlayerHit");
            other.GetComponent<Player_Stats>().PlayerTakeDamage(Block_damage);
        }
    }
    public void BlockTakeDamage(float damageAmount)
    {
        block_hp -= damageAmount;
        if (block_hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
