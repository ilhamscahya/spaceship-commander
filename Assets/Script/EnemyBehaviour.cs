using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {
	public float movementSpeed = 1;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
        StartCoroutine(Faster());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.left * movementSpeed * Time.deltaTime);

	}

    IEnumerator Faster()
    {
        while (true)
        {
            yield return new WaitForSeconds(60);
            movementSpeed += 1;

        }
    }

}
