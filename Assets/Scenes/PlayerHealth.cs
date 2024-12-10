using UnityEngine;
using TMPro; // Pour utiliser TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public TextMeshProUGUI healthText; // Référence au texte TextMeshPro UI

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject); // Détruit le joueur
        }

        // Met à jour le texte des vies restantes
        UpdateHealthText();
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Nombre de vies = " + health;
        }
    }
}
