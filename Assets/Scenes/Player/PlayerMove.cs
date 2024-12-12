using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes
{
    public class PlayerMove : MonoBehaviour
    {
        public float speed = 8f; // Vitesse de déplacement
        public float BorderWidth = 10f; // Limite des bordures

        void Update()
        {
            // Lecture des touches directionnelles ou des axes d'entrée
            float horizontal = Input.GetAxis("Horizontal");

            // Calcul du déplacement
            Vector2 movement = new Vector2(horizontal, 0) * speed * Time.deltaTime;

            // Vérification des limites avec BorderWidth
            if ((transform.position.x < -BorderWidth && movement.x < 0) || (transform.position.x > BorderWidth && movement.x > 0))
                return;

            // Appliquer le mouvement
            transform.Translate(movement);
        }
    }
}


