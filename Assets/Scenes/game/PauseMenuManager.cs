using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI;  // Référence au menu de pause (Panel)
    public Button resumeButton;     // Bouton Reprendre
    public Button mainMenuButton;       // Bouton Quitter
    public AudioSource gameTheme;       // Thème principal
    public AudioSource engineSound;     // Son moteur

    private bool isPaused = false;  // Si le jeu est en pause ou non

    void Start()
    {
        // Désactivez le menu de pause au début
        pauseMenuUI.SetActive(false);

        // Assurez-vous que les boutons sont correctement assignés
        resumeButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    void Update()
    {
        // Si le joueur appuie sur la touche 'Escape', activer ou désactiver le menu de pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);   // Affiche le menu de pause
        Time.timeScale = 0f;           // Met le jeu en pause (arrête le temps)
        gameTheme.mute = true;
        engineSound.mute = true;
    }

    void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);  // Cache le menu de pause
        Time.timeScale = 1f;           // Reprend le jeu (le temps reprend)
        gameTheme.mute = false;
        engineSound.mute = false;
    }

    void MainMenu()
    {
        // Réinitialiser Time.timeScale avant de changer de scène
        Time.timeScale = 1f;

        // Optionnellement, détruire des objets persistants ou réinitialiser des éléments du jeu
        ResetGame();

        // Charger la scène du menu principal
        SceneManager.LoadScene("MainMenu");
    }
    void ResetGame()
    {
        // Désactiver ou supprimer les objets qui ne doivent pas persister entre les scènes
        var gameObjects = FindObjectsOfType<GameObject>();
        foreach (var go in gameObjects)
        {
            // Suppression des objets persistants, mais en évitant de supprimer la scène de gestion du menu
            if (!go.CompareTag("MainMenu"))
            {
                Destroy(go);
            }
        }
    }



    // Méthode pour vérifier si le jeu est en pause
    public bool IsPaused()
    {
        return isPaused;
    }
}
