using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject NormalBullet; // Petite balle
    public GameObject LargeBullet; // Grande balle
    public Camera MainCamera; // Référence à la caméra principale
    public float ZoomSpeed = 2f; // Vitesse de zoom/dézoom
    public float minZoom = 5f; // Zoom minimum
    public float MaxZoom = 9f; // Zoom maximum
    public int MaxBullets = 5; // Nombre maximum de balles
    public int CurrentBullets = 0; // Nombre de balles utilisées

    public PauseMenuManager pauseMenuManager; // Référence au script de gestion de pause
    public AudioClip ShootMediumBullet; // Son du tir

    public AudioClip ShootLargeBullet;
    public AudioSource audioSource; // Référence à l'CurrentBullets


    void Start()
    {
        // Si la caméra principale n'est pas assignée, utiliser celle par défaut
        if (MainCamera == null)
        {
            MainCamera = Camera.main;
        }

        CurrentBullets = 0; // Initialisation du compteur de balles


        // Trouver le PauseMenuManager dans la scène
        pauseMenuManager = FindObjectOfType<PauseMenuManager>();

        // Récupérer ou ajouter un AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

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
        if (scrollInput != 0 && !pauseMenuManager.GetComponent<PauseMenuManager>().isPaused)
        {
            MainCamera.orthographicSize -= scrollInput * ZoomSpeed; // Utiliser un zoom intuitif
            MainCamera.orthographicSize = Mathf.Clamp(MainCamera.orthographicSize, minZoom, MaxZoom);
        }
    }

    void HandleShooting()
    {
        // Vérifier si le joueur appuie sur le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0) && CurrentBullets < MaxBullets && !pauseMenuManager.GetComponent<PauseMenuManager>().isPaused)
        {
            string bulletType;
            GameObject bullet;

            // Vérifier la taille de la caméra pour déterminer le type de tir
            if (MainCamera.orthographicSize < 6f)
            {
                bullet = LargeBullet;
                bulletType = "Large";

                GameObject newBullet = Instantiate(LargeBullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);

                // Ajouter le type de balle au script PlayerBulletMove
                PlayerBulletMove bulletScript = newBullet.GetComponent<PlayerBulletMove>();
                if (bulletScript != null)
                {
                    bulletScript.SetBulletType(bulletType);
                }

                // Jouer le son de tir
                if (audioSource != null && ShootLargeBullet != null)
                {
                    audioSource.clip = ShootLargeBullet;
                    audioSource.Play();
                }
            }
            else
            {
                bullet = NormalBullet;
                bulletType = "Normal";

                // Si la caméra est à 9 ou plus (non zoomée), tirer une balle normale
                GameObject newBullet = Instantiate(NormalBullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);

                // Ajouter le type de balle au script PlayerBulletMove
                PlayerBulletMove bulletScript = newBullet.GetComponent<PlayerBulletMove>();
                if (bulletScript != null)
                {
                    bulletScript.SetBulletType(bulletType);
                }

                // Jouer le son de tir
                if (audioSource != null && ShootMediumBullet != null)
                {
                    audioSource.clip = ShootMediumBullet;
                    audioSource.Play();
                }
            }

            // Incrémenter le compteur de balles
            CurrentBullets++;
        }

        // Vérifier si le joueur appuie sur "R" pour recharger
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void Reload()
    {
        CurrentBullets = 0; // Réinitialiser le compteur de balles
        Debug.Log("Recharge terminée !");
    }
}
