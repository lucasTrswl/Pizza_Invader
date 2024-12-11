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
    public int maxBullets = 5; // Limite de tirs
    public int currentBullets = 0; // Compteur de tirs actuels

    void Start()
    {
        // Si la caméra principale n'est pas assignée, utiliser celle par défaut
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        currentBullets = 0; // Initialisation du compteur de balles
    }

    void Update()
    {
        HandleZoom();
        HandleShooting();
    }

    void HandleZoom()
    {
        // Gestion du zoom avec la molette de la souris
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0)
        {
            mainCamera.orthographicSize -= scrollInput * zoomSpeed; // Utiliser un zoom intuitif
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minZoom, maxZoom);
        }
    }

    void HandleShooting()
    {
        // Vérifier si le joueur appuie sur le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0) && currentBullets < maxBullets)
        {
            // Vérifier la taille de la caméra pour déterminer le type de tir
            if (mainCamera.orthographicSize < 6f)
            {
                // Si la caméra est en dessous de 9 (zoom), tirer une grande balle
                Instantiate(largeBullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }
            else
            {
                // Si la caméra est à 9 ou plus (non zoomée), tirer une balle normale
                Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            }

            // Incrémenter le compteur de balles
            currentBullets++;
        }

        // Vérifier si le joueur appuie sur "R" pour recharger
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Reload()
    {
        currentBullets = 0; // Réinitialiser le compteur de balles
        Debug.Log("Recharge terminée !");
    }
}
