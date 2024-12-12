using UnityEngine;
using UnityEngine.UI; // Pour accéder au composant Image
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

        // Créer les icônes pour le nombre maximum de balles
        for (int i = 0; i < playerShoot.MaxBullets; i++)
        {
            GameObject bulletIcon = Instantiate(bulletPrefab, bulletContainer);
            bulletIcons.Add(bulletIcon);
        }

        UpdateBulletsUI();
    }

    void Update()
    {
        // Mettre à jour les icônes si le nombre de balles change
        UpdateBulletsUI();
    }

    void UpdateBulletsUI()
    {
        int remainingBullets = playerShoot.MaxBullets - playerShoot.CurrentBullets;

        for (int i = 0; i < bulletIcons.Count; i++)
        {
            Image bulletImage = bulletIcons[i].GetComponent<Image>();

            if (bulletImage != null)
            {
                if (i < remainingBullets)
                {
                    // Balles restantes : Pleinement opaques
                    bulletImage.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    // Balles tirées : Semi-transparentes
                    bulletImage.color = new Color(1, 1, 1, 0.3f);
                }
            }
        }
    }
}
