using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3; // Points de vie de l'ennemi
    public AudioSource deathSound; // Référence à l'AudioSource qui joue le son de la mort

    private WaveManager waveManager; // Référence au WaveManager


    void Start()
    {
        GameObject g = GameObject.Find("EnemyDeathSound");
        // Trouver le WaveManager dans la scène
        waveManager = FindObjectOfType<WaveManager>();

        // Si l'AudioSource n'est pas assigné dans l'inspecteur, on tente de le récupérer sur l'objet
        if (deathSound == null)
        {
            deathSound = g.GetComponent<AudioSource>();

            Debug.Log(deathSound.name);
        }
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
        // Jouer le son de la mort
        if (deathSound != null)
        {
            deathSound.Play();
        }

        // Appel de la méthode EnemyDefeated du WaveManager pour signaler que l'ennemi est tué
        if (waveManager != null)
        {
            waveManager.EnemyDefeated(); // Signale que l'ennemi est tué
        }

        // Détruire l'ennemi après un court délai pour permettre au son de jouer
        Destroy(gameObject); // Détruit l'ennemi après la durée du clip audio
    }
}
