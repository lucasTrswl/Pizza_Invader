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
    public int CurrentBullets = 5; // Nombre de balles disponible

    public PauseMenuManager pauseMenuManager; // Référence au script de gestion de pause
    public AudioSource ShootMediumBullet; // Son du tir

    public AudioSource ShootLargeBullet;
    public bool isBigBullet = false;
    public bool isReloading = false;
    public float reloadTime = 2;
    public float reloadTimeIncrement = 0.5f;
    private float reloadTimer = 2;


    void Start()
    {
        // Si la caméra principale n'est pas assignée, utiliser celle par défaut
        if (MainCamera == null)
        {
            MainCamera = Camera.main;
        }

        CurrentBullets = 5; // Initialisation du compteur de balles


        // Trouver le PauseMenuManager dans la scène
        pauseMenuManager = FindObjectOfType<PauseMenuManager>();

    }

    void Update()
    {
        HandleZoom();
        HandleShooting();
        HandleReloading();
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
        isBigBullet = MainCamera.orthographicSize < 6f;
        // Vérifier si le joueur appuie sur le bouton gauche de la souris
        if (Input.GetMouseButtonDown(0) && CurrentBullets > 0 && !pauseMenuManager.GetComponent<PauseMenuManager>().isPaused && !isReloading)
        {

            // Vérifier la taille de la caméra pour déterminer le type de tir
            GameObject bullet = isBigBullet ? LargeBullet : NormalBullet;


            GameObject newBullet = Instantiate(bullet, transform.position + Vector3.up * 0.5f, Quaternion.identity);

            // Ajouter le type de balle au script PlayerBulletMove
            PlayerBulletMove bulletScript = newBullet.GetComponent<PlayerBulletMove>();
            if (bulletScript != null)
            {
                bulletScript.SetBigBullet(isBigBullet);
            }

            // Jouer le son de tir
            if (((isBigBullet && ShootLargeBullet != null) || (!isBigBullet && ShootMediumBullet != null)))
            {
                if (isBigBullet)
                {
                    ShootLargeBullet.Play();
                }
                else
                {
                    ShootMediumBullet.Play();
                }
            }


            // Incrémenter le compteur de balles, bah non du coup ?
            CurrentBullets--;
        }

        // Vérifier si le joueur appuie sur "R" pour recharger
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    void HandleReloading()
    {
        if (isReloading)
        {

            reloadTimer -= Time.deltaTime;

            if (reloadTimer <= 0)
            {
                isReloading = false;
                CurrentBullets = MaxBullets;
                reloadTimer = reloadTime;
            }
        }
    }

    void Reload()
    {
        // On va éviter le reload instant sinon c'est cheat.
        if (isReloading || CurrentBullets == MaxBullets) return;

        isReloading = true;
    }
}
