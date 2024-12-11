using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2; // Nombre initial de vies de l'ennemi

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Appeler une méthode pour gérer la mort de l'ennemi
            Die();
        }
    }

    void Die()
    {
        // Actions à effectuer lorsque l'ennemi meurt
        Debug.Log("Enemy is Dead");
        Destroy(gameObject); // Détruire l'ennemi
    }
}
