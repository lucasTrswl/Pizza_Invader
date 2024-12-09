using UnityEngine;

public class MoveObject : MonoBehaviour
{
        void Start() {
            
        }

    public float speed = 5f; // Vitesse de déplacement

    void Update()
    {
        // Lecture des touches directionnelles ou des axes d'entrée
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calcul du déplacement
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        // Appliquer le mouvement
        transform.Translate(movement);
    }

}

