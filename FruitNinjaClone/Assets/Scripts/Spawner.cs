using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject [] objToSpawn;
    public Transform[] spawnPlaces;
    public float minWait = .3f;
    public float maxWait = 1f;
    public float minForce = 12;
    public float maxForce = 17;
    private void Start()
    {
        StartCoroutine(SpawnFruits());
    }
    private IEnumerator SpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Transform spawn = spawnPlaces[Random.Range(0, spawnPlaces.Length)];
            GameObject go = null;
            float chance = Random.Range(0, 100);
            if (chance < 15)
            {
                go = objToSpawn[0];
            }
            else
            {
                go = objToSpawn[Random.Range(1, objToSpawn.Length)];
            }
            GameObject fruit = Instantiate(go, spawn.position, spawn.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(spawn.transform.up * Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            Destroy(fruit,5);
        }
    }

}
