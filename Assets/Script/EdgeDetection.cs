using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag.Equals("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }

}
