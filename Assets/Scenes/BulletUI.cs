using UnityEngine;
using TMPro;

public class BulletUI : MonoBehaviour
{
    public PlayerShoot playerShoot;
    public TextMeshProUGUI bulletText;

    // Update is called once per frame
    void Update()
    {
        int remainingBullets = playerShoot.maxBullets - playerShoot.currentBullets;
        bulletText.text = "Bullets: " + remainingBullets.ToString(); // Convertir en chaîne
    }
}
