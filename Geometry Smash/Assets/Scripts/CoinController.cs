using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinController : MonoBehaviour
{
    [SerializeField] private GameObject spark;
    void Start()
    {
        Animator anim = GetComponent<Animator>();

        anim.Play("Coin_anim", 0, Random.Range(0.0f, 1.0f));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Instantiate(spark, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}