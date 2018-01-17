using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    private float[] array = {-3, 0, 3};
    public float spawnTime = 2000f;
    public GameObject enemy;
    Vector2 whereToSpawn;
    public Transform myTransform;

    // Use this for initialization

    private void Awake()
    {
        myTransform = transform;
    }
    void Start()
    {
        StartCoroutine(SpawnTimeDelay());
    }

    IEnumerator SpawnTimeDelay()
    {
        while(true)
        {
            var newY = Random.Range(0, 3);
            Instantiate(enemy, new Vector3(myTransform.position.x ,transform.position.y + array[newY], 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnTime);
            
        }
    }
}
