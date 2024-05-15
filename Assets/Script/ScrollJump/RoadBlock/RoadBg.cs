using UnityEngine;

public class RoadBg : MonoBehaviour
{
    [SerializeField] private float speed;

    void FixedUpdate()
    {
        transform.Translate(-transform.right * speed * Time.deltaTime);
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
