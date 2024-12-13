using System;
using UnityEngine;

public class PlayerBulletMove : MonoBehaviour
{
    private bool _isBigBullet; // Type de la balle (Normal, Large)
    public float bulletSpeed = 9f; // Vitesse de la balle (modifiable dans l'inspecteur)

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f); // Détruit la balle après 5 secondes
    }

    // Update is called once per frame
    void Update()
    {
        // Déplacer la balle vers le haut à une vitesse ajustable
        Vector3 newPosition = transform.position;
        newPosition.y += bulletSpeed * Time.deltaTime; // Utiliser bulletSpeed pour la vitesse de déplacement
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Vérifie si l'objet touché est un ennemi
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            int damage = _isBigBullet ? 2 : 1;

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Désactiver le collider pour éviter d'autres collisions
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject); // Détruire la balle après collision
        }
    }

    public void SetBigBullet(bool isBigBullet)
    {
        _isBigBullet = isBigBullet;
    }
}
