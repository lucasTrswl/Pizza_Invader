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
            // Réduit les points de vie de l'ennemi
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // Inflige 1 point de dégâts

                // Si l'ennemi est mort, le détruire
                if (enemyHealth.health <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }

            // Détruit l'objet actuel (par exemple, le projectile)
            Destroy(this.gameObject);
        }
    }

