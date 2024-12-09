using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MainCamera"){
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
        }

      
    }
}
