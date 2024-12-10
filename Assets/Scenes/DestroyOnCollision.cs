using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish")) {
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        }

      
    }
}
