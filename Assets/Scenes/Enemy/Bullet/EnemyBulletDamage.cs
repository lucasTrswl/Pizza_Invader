using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f); // Détruit la balle au bout de 5 secondes
    }

    void Update()
    {
        // Déplace la balle vers le bas
        Vector3 newPosition = transform.position;
        newPosition.y -= 3 * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            // Réduit les points de vie du joueur
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Inflige 1 point de dégâts
            }

            Destroy(gameObject); // Détruit la balle après collision
        }
    }
}
