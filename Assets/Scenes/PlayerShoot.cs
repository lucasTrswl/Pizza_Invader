using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Petite balle
    public GameObject largeBullet; // Grande balle
    public Camera mainCamera; // Référence à la caméra principale
    public float zoomSpeed = 2f; // Vitesse de zoom/dézoom
    public float minZoom = 5f; // Zoom minimum
    public float maxZoom = 20f; // Zoom maximum
    public float actionZoomThreshold = 15f; // Niveau de zoom pour déclencher l'action

    public GameObject bulletPrefab; // Préfabriqué de balle
    public int maxBullets = 5; // Limite de tirs
    public int currentBullets = 0; // Compteur de tirs actuels
    
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        
         currentBullets = 0; // Initialiser le nombre de tirs à 0 au début


    

  

    void Update()
    {
        // Gestion du zoom avec la molette
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            mainCamera.orthographicSize += scrollInput * zoomSpeed; // Inversé pour un zoom intuitif
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
        }
        
        // Gestion des tirs
        if (Input.GetMouseButtonDown(0))
        {
            if (mainCamera.orthographicSize <= actionZoomThreshold)
            {
                // Tir avec une grande balle (zoom proche)
                Instantiate(largeBullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
            else
            {
                // Tir avec une balle normale (zoom éloigné)
                Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }

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
