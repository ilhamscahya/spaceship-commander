using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBullet : MonoBehaviour {

    GameObject spaceshipscore;
    private VoiceControl vc;

    private void Start()
    {
        GameObject ship = GameObject.FindGameObjectWithTag("Player");
        vc = ship.GetComponent<VoiceControl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Enemy"))
        {
            vc.AddScore(1);
            Destroy(other.gameObject);
        }

        if(other.tag.Equals("Bullet"))
        {
            Destroy(other.gameObject);
        }
    }
}
