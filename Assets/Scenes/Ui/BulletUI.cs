using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class BulletUI : MonoBehaviour
{
    public PlayerShoot playerShoot; // Référence au script PlayerShoot
    public GameObject bulletPrefab; // Le prefab de l'icône de la balle
    public Transform bulletContainer; // Le parent contenant les icônes des munitions

    private List<GameObject> bulletIcons = new List<GameObject>(); // Liste des icônes actives

    void Start()
    {
        if (playerShoot == null)
        {
            playerShoot = FindObjectOfType<PlayerShoot>();
        }

        for (int i = 0; i < 5; i++)
        {
            GameObject bulletIcon = Instantiate(bulletPrefab, bulletContainer);
            bulletIcons.Add(bulletIcon);
        }

        UpdateBulletsUI();
    }

    void Update()
    {
        // Vérifier si le nombre de munitions a changé
        UpdateBulletsUI();
    }

    void UpdateBulletsUI()
    {
        int remainingBullets = playerShoot.MaxBullets - playerShoot.CurrentBullets;

        for (int i = 0; i < 5; i++)
        {
            bulletIcons[i].SetActive(i < remainingBullets);
        }
    }

}
