using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;
    public void Update()
    {
    }
    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody [] rbOnSliced = inst.transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbOnSliced)
        {
            rb.transform.rotation = Random.rotation;
            rb.AddExplosionForce(Random.Range(300, 600), transform.position, 5f);
        }
        FindObjectOfType<GameManager>().IncreaseScore(1);
        Destroy(gameObject);
        Destroy(inst.gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        else
        {
            CreateSlicedFruit();
        }
    }
}
