using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public float MaxSpeed = 10f;
    public float MinSpeed = 5f;
    private float Speed;


    void Start()
    {
        Speed = Random.Range(MinSpeed, MaxSpeed);    
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 displacement = new Vector2(0, -1) * Speed * Time.deltaTime;
        gameObject.transform.Translate(displacement);

        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
