using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    public int health = 3; // Nombre initial de vies de l'ennemi
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"Enemy took {damage} damage, remaining health: {health}"); // Afficher dégâts et santé restante

        if (health <= 0)
        {
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
