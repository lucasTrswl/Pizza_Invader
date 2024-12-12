using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
    public float bulletSpeed = 5f; // Vitesse de la balle ennemie (modifiable dans l'inspecteur)

    void Start()
    {
        Destroy(gameObject, 5f); // Détruit la balle au bout de 5 secondes
    }

    void Update()
    {
        // Déplace la balle vers le bas à la vitesse spécifiée
        Vector3 newPosition = transform.position;
        newPosition.y -= bulletSpeed * Time.deltaTime; // Utilise bulletSpeed pour la vitesse de déplacement
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

            Destroy(gameObject); // Détruire la balle après collision
        }
    }
}
