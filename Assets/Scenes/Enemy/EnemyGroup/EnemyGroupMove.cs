using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scenes
{
    public class EnemyGroupMove: MonoBehaviour
    {
        public float speed;
        private float moveDirection = 0;
        public float BorderWidth = 10;
        private float yDisplacement = 0;
        private float x = 0;
        public float levitatingSpeed = 0.005f;
        public float levitatingAmplitude = 1;
        
        // Use this for initialization
        void Start()
        {
            moveDirection = Random.Range(0, 1) == 1 ? -1 : 1;
            yDisplacement = transform.position.y;
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

            x += levitatingSpeed * Time.deltaTime;

            if (x > 2 * Mathf.PI)
            {
                x = 0;
            } 

            transform.Translate(movement);

            transform.position = new Vector3(transform.position.x, yDisplacement + (levitatingAmplitude * Mathf.Sin(x)), 0);
        }
    }
}