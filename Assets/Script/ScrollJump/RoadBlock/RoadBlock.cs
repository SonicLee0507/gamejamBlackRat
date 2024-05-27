using UnityEngine;

public class RoadBlock : MonoBehaviour
{
    public GameControl_SJ gameControl;
    [SerializeField] private float speed;
    [SerializeField] private float Block_damage;
    [SerializeField] public float block_hp;

    [SerializeField] private Rigidbody rig;

    [SerializeField] private bool isBirdy = false;
    // Update is called once per frame
    private void Start()
    {
        GameObject gameObject;
        gameObject = GameObject.FindGameObjectWithTag("GameController");

        gameControl = gameObject.GetComponent<GameControl_SJ>();
    }
    void FixedUpdate()
    {
        transform.Translate(-transform.right*speed*Time.deltaTime * gameControl.totalSpeed);
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

            if (other.GetComponent<Player_Stats>().player_Control.isCaptureing)
            {
                if (isBirdy)
                {
                    other.GetComponent<Player_Stats>().PlayerHeal(Block_damage);
                    BlockTakeDamage(Block_damage);
                }
                else
                {
                    other.GetComponent<Player_Stats>().PlayerTakeDamage(Block_damage);
                    BlockTakeDamage(Block_damage);
                }
            }
            else
            {
                other.GetComponent<Player_Stats>().PlayerTakeDamage(Block_damage);
            }


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
