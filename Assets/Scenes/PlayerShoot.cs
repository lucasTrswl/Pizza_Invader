using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            // Create bullet at current position
            GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            
           
        }
    }
}
