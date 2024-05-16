using UnityEngine;

public class RoadBg : MonoBehaviour
{
    public GameControl_SJ gameControl;
    [SerializeField] private float speed;
    private void Start()
    {
        GameObject gameObject;
        gameObject = GameObject.FindGameObjectWithTag("GameController");

        gameControl = gameObject.GetComponent<GameControl_SJ>();
    }
    void FixedUpdate()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime * gameControl.totalSpeed);
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
