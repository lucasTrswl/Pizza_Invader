using UnityEngine;
using UnityEngine.UI; // Pour accéder au composant Image
using System.Collections.Generic;
using System.Drawing;

public class BulletUI : MonoBehaviour
{
    public PlayerShoot playerShoot; // Référence au script PlayerShoot
    public GameObject bulletPrefabSmall; // Le prefab de l'icône de la balle
    public GameObject bulletPrefabBig; // Le prefab de l'icône de la balle GRANDE
    public Transform bulletContainer; // Le parent contenant les icônes des munitions
    public float reloadTimer = 0;
    public float reloadAnimationSpeed = 0.5f;

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
            GameObject bulletIconType = bulletPrefabSmall;
            GameObject bulletIcon = Instantiate(bulletIconType, bulletContainer);
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
        int remainingBullets = playerShoot.CurrentBullets;

        for (int i = 0; i < bulletIcons.Count; i++)
        {
            Image bulletImage = bulletIcons[i].GetComponent<Image>();
            Debug.Log(bulletImage.name);
            bulletImage.sprite = playerShoot.isBigBullet ? bulletPrefabBig.GetComponent<Image>().sprite : bulletPrefabSmall.GetComponent<Image>().sprite;

            if (bulletImage != null)
            {
                if (playerShoot.isReloading)
                {
                    reloadTimer += reloadAnimationSpeed * Time.deltaTime;
                    if (reloadTimer > 2 * Mathf.PI)
                    {
                        reloadTimer = 0;
                    }
                    bulletImage.color = new UnityEngine.Color(1, 1, 1, (Mathf.Sin(reloadTimer) + 1) / 2);
                }
                else if (i < remainingBullets)
                {
                    // Balles restantes : Pleinement opaques
                    bulletImage.color = new UnityEngine.Color(1, 1, 1, 1);
                }
                else
                {
                    // Balles tirées : Semi-transparentes
                    bulletImage.color = new UnityEngine.Color(1, 1, 1, 0.3f);
                }
            }
        }
    }
}
