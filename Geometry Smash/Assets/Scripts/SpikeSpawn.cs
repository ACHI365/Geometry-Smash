using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawn : MonoBehaviour
{
    [SerializeField] private Transform pos1, pos2, pos3;
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject coin;
    void Start()
    {
        var x = Random.Range(1, 3);
        if (x == 1)
        {
            GameObject Spike = Instantiate(spike);
            Spike.transform.position = pos1.position;
            Spike.transform.SetParent(transform);
        }
        x = Random.Range(1, 3);
        if (x == 1)
        {
            GameObject Spike = Instantiate(spike);
            Spike.transform.position = pos2.position;
            Spike.transform.SetParent(transform);
        }
        x = Random.Range(1, 3);
        if (x == 1)
        {
            GameObject Coin = Instantiate(coin);
            Coin.transform.position = pos3.position;
            Coin.transform.SetParent(transform);
        }
    }
}
