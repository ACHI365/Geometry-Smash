using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehaviour : MonoBehaviour
{
    [SerializeField] private Transform player;
    void Start()
    {
        player = GameObject.Find("Player").transform;
    } 
    void Update()
    {
        if (transform.position.x < (player.transform.position.x - 10))
        {
            Destroy(gameObject);
        }
    }
}