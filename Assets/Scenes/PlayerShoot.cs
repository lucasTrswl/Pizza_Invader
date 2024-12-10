using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Préfabriqué de balle
    public int maxBullets = 5; // Limite de tirs
    public int currentBullets = 0; // Compteur de tirs actuels

    // Start is called before the first frame update
    void Start()
    {
        currentBullets = 0; // Initialiser le nombre de tirs à 0 au début
    }

    // Update is called once per frame
    void Update()
    {
        // Vérifier si le joueur appuie sur le bouton de tir (clic gauche de la souris)
        if (Input.GetMouseButtonDown(0) && currentBullets < maxBullets)
        {
            // Créer la balle à la position actuelle du joueur
            GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);

            // Incrémenter le nombre de balles tirées
            currentBullets++;
        }

        // Vérifier si le joueur appuie sur "R" pour recharger
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    // Fonction pour recharger les balles
    void Reload()
    {
        currentBullets = 0; // Réinitialiser le compteur de balles
        Debug.Log("Recharge terminée !");
    }
}
