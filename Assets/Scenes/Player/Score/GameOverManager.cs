using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Référence au champ Text - TextMeshPro dans l'Inspector

    void Start()
    {
        // Vérifie que le champ est assigné dans l'Inspector
        if (scoreText != null)
        {
            // Mets à jour le texte avec le score
            scoreText.text = GameData.PlayerScore.ToString();
        }
       
    }
}
