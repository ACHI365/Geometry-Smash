using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class SpawnMap : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    [SerializeField] private int offset;
    [SerializeField] private Transform storage;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            GameObject floorPiece = Instantiate(floor);
            floorPiece.transform.position = new Vector3(transform.position.x + offset, -3.32f, 0);
            floorPiece.transform.SetParent(storage);
        }
    }

    public void Clear()
    {
        for (int i = 0; i < storage.childCount; i++)
        {
            Destroy(storage.GetChild(i).gameObject);
        }
    }
}