using UnityEngine;
using TMPro; // Pour utiliser TextMeshPro
using UnityEngine.UI; // Pour travailler avec les UI Image
using UnityEngine.SceneManagement;
using System.Collections.Generic; // Pour la liste des icônes

public class PlayerHealth : MonoBehaviour
{
    public int health = 3; // Nombre initial de points de vie

    public int maxHealth = 3; // Nombre maximum de vies (au cas où vous voulez un maximum)

    public TextMeshProUGUI healthText; // Référence au texte TextMeshPro UI
    public GameObject heartPrefab; // Le prefab de l'icône de vie (par exemple, un cœur)
    public Transform livesContainer; // Conteneur des icônes de vie

    public AudioClip deathSound; // Son joué lorsque le joueur meurt
    public AudioSource damageSound;    // Son joué lorsque le joueur prends des dégats

    private List<GameObject> heartIcons = new List<GameObject>(); // Liste des icônes de vie actives

    void Start()
    {
        // Initialiser l'affichage des vies dès le début
        UpdateHealthUI();
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
            // Mettre à jour l'affichage des vies et du texte
            UpdateHealthUI();
            UpdateHealthText();
            damageSound.Play();
        }
    }

    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Player Health : " + health.ToString();
        }
    }

    void UpdateHealthUI()
    {
        // Supprimer les anciennes icônes de vie
        foreach (GameObject heart in heartIcons)
        {
            Destroy(heart);
        }
        heartIcons.Clear();

        // Créer les nouvelles icônes de vie
        for (int i = 0; i < health; i++)
        {
            GameObject heartIcon = Instantiate(heartPrefab, livesContainer);
            heartIcons.Add(heartIcon);
        }

        // Ajouter des icônes vides (pour les vies manquantes)
        for (int i = health; i < maxHealth; i++)
        {
            GameObject heartIcon = Instantiate(heartPrefab, livesContainer);
            heartIcon.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f); // Rendre l'icône semi-transparente pour les vies manquantes
            heartIcons.Add(heartIcon);
        }
    }

    void Die()
    {

        // Détruit le joueur ou effectue d'autres actions comme un écran Game Over
        Debug.Log("Player is Dead");

        // Optionnel : Réinitialiser ou désactiver le texte de la santé
        if (healthText != null)
        {
            healthText.text = "Player Health : 0";
        }

        GameData.Save();
        Debug.Log("Score actuel : " + GameData.PlayerScore);

        // Charger la scène Game Over après un délai pour permettre au son de jouer
        Destroy(gameObject, 1.5f); // Attends 1.5 secondes avant de détruire le joueur
        SceneManager.LoadScene("GameOver");
    }

    public void Heal(int healAmount)
    {
        if (health < maxHealth)
        {
            health += healAmount;
            UpdateHealthUI();
        }
        else
        {

        }
    }
}
