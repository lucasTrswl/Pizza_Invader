using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement

    void Update()
    {
        // Lecture des touches directionnelles ou des axes d'entrée
        float horizontal = Input.GetAxis("Horizontal");

        // Calcul du déplacement
        Vector2 movement = new Vector2(horizontal, 0) * speed * Time.deltaTime;

        if ((transform.position.x < -10 && movement.x < 0) || (transform.position.x > 10 && movement.x > 0)) return;


        // Appliquer le mouvement
        transform.Translate(movement);
    }

}

