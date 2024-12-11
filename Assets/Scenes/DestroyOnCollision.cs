using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string tag = "Enemy";
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag(tag))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }


    }
}
