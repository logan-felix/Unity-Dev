using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(1, 10), Tooltip("Change the speed")] public float speed = 2;
    public GameObject prefab;

    private void Awake()
    {
        print("awake");
    }

    void Start()
    {
        print("start");
    }

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        velocity.x = Input.GetAxis("Horizontal");
        velocity.z = Input.GetAxis("Vertical");
        transform.position += velocity * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(prefab, transform.position + Vector3.one, Quaternion.identity);
        }
    }
}
