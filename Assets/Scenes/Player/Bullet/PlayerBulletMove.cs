using UnityEngine;


public class PlayerBulletMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        // Optional: Initialization logic if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet upward
        Vector3 newPosition = transform.position;
        newPosition.y += 3 * Time.deltaTime;
        transform.position = newPosition;
    }

}