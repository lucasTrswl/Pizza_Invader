using System.Collections;
using UnityEngine;

namespace Assets.Scenes
{
    public class EnemyIntelligence: MonoBehaviour
    {
        public float speed;
        private int moveDirection;
        // Use this for initialization
        void Start()
        {
            speed = 5;
            moveDirection = Random.Range(0, 1) == 1 ? -1 : 1;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 movement = new Vector2(moveDirection, 0) * speed * Time.deltaTime;

            if ((transform.position.x < -10 && movement.x < 0) || (transform.position.x > 10 && movement.x > 0))
            {
                moveDirection *= -1;
                return;
            }

            transform.Translate(movement);
        }
    }
}