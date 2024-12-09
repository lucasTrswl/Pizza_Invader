using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish"){
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        }

      
    }
}
