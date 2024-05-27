
using UnityEngine;

public class ScrollJump : MonoBehaviour
{
    [SerializeField] private Rigidbody rig;
    public float gravityScale = 1.0f;
    public static float globalGravity = -9.81f;

    [SerializeField] private float jumpforce = 10f;
    [SerializeField] public int jumpnumb = 1;

    [SerializeField] private GameObject groundFlare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) & jumpnumb >= 1)
        {
            rig.velocity = new Vector3(0, jumpforce, 0);
            jumpnumb -= 1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Floor")
        {       
            Debug.Log("HEHE");
            jumpnumb = 2;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Floor")
        {
            groundFlare.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor")
        {
            groundFlare.SetActive(false);
        }
    }
}
