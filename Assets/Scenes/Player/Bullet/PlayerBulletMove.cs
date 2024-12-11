using UnityEngine;


public class PlayerBulletMove : MonoBehaviour
{
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
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy")) // Vérifie si l'objet touché est un ennemi
        {
            // Réduit les points de vie de l'ennemi
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // Inflige 1 point de dégâts à l'ennemi
            }

            Destroy(gameObject); // Détruit la balle après la collision
        }
    }

}