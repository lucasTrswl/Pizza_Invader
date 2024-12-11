using System.Collections;
using UnityEngine;

namespace Assets.Scenes
{
    public class EnemyGroupMove: MonoBehaviour
    {
        public float speed;
        private float moveDirection = 0;
        public float BorderWidth = 10;

        // Use this for initialization
        void Start()
        {
            moveDirection = Random.Range(0, 1) == 1 ? -1 : 1;
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 movement = new Vector2(moveDirection, 0) * speed * Time.deltaTime;

            if ((transform.position.x < -BorderWidth && movement.x < 0) || (transform.position.x > BorderWidth && movement.x > 0))
            {
                moveDirection *=  -1;
                return;
            }

            transform.Translate(movement);
        }
    }
}