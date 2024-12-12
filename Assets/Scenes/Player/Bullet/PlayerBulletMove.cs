using UnityEngine;


public class PlayerBulletMove : MonoBehaviour
{
    private string bulletType; // Type de la balle (Normal, Large, etc.)

    public void SetBulletType(string type)
    {
        bulletType = type;
        Debug.Log("Bullet Type: " + bulletType); // Affiche le type de balle dans les logs
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
        // Optional: Initialization logic if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bullet upward
        Vector3 newPosition = transform.position;
        newPosition.y += 3 * Time.deltaTime;
        transform.position = newPosition;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Vérifie si l'objet touché est un ennemi
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                if (bulletType == "Normal")
                {
                    Debug.Log("Applying 1 damage");
                    enemyHealth.TakeDamage(1);
                }
                else if (bulletType == "Large")
                {
                    Debug.Log("Applying 2 damage");
                    enemyHealth.TakeDamage(2);
                }
                else
                {
                    Debug.LogWarning("Unknown bullet type: " + bulletType);
                }
            }

            // Désactiver le collider pour éviter d'autres collisions
            GetComponent<Collider2D>().enabled = false;

            Destroy(gameObject); // Détruire la balle après collision
        }


    }
}
