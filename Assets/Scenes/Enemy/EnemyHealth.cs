using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3; // Points de vie de l'ennemi

    private WaveManager waveManager; // Référence au WaveManager

    void Start()
    {
        // Trouver le WaveManager dans la scène
        waveManager = FindObjectOfType<WaveManager>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Appel de la méthode EnemyDefeated du WaveManager pour signaler que l'ennemi est tué
        if (waveManager != null)
        {
            waveManager.EnemyDefeated(); // Signale que l'ennemi est tué
        }

        // Détruire l'ennemi
        Destroy(gameObject);
    }
}
