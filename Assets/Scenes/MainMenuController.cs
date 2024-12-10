using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Fonction appelée pour quitter le jeu
    public void QuitGame()
    {
        Debug.Log("Quitter le jeu !");
        Application.Quit(); // Ne fonctionne que dans un build
    }
}
