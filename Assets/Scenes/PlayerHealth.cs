using UnityEngine;
using TMPro; // Pour utiliser TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // Nombre initial de points de vie
    public TextMeshProUGUI healthText; // Référence au texte TextMeshPro UI

    void Start()
    {
        // Mettre à jour le texte des vies dès le début
        UpdateHealthText();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Appeler une méthode pour gérer la mort du joueur
            Die();
        }
        else
        {
            // Mettre à jour le texte des vies restantes
            UpdateHealthText();
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Player Health : " + health.ToString();
        }
    }

    void Die()
    {
        // Détruit le joueur ou effectue d'autres actions comme un écran Game Over
        Debug.Log("Player is Dead");
        Destroy(gameObject);

        // Optionnel : Réinitialiser ou désactiver le texte de la santé
        if (healthText != null)
        {
            healthText.text = "Player Health : 0";
        }
    }
}
