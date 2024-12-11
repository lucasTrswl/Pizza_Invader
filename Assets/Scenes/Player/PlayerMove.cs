using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Vitesse de déplacement

    public float borderScene = 10;

    void Update()
    {
        // Lecture des touches directionnelles ou des axes d'entrée
        float horizontal = Input.GetAxis("Horizontal");

        // Calcul du déplacement
        Vector2 movement = new Vector2(horizontal, 0) * speed * Time.deltaTime;

        // empêche de sortir de la scène
        if ((transform.position.x < -borderScene && movement.x < 0) || (transform.position.x > borderScene && movement.x > 0)) return;


        // Appliquer le mouvement
        transform.Translate(movement);
    }

}

