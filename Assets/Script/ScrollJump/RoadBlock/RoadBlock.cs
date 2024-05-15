using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float Block_damage;

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
            other.GetComponent<Player_Control>().PlayerTakeDamage(Block_damage);
            Destroy(gameObject);
        }

    }
}
