using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Objects;
    public int Amount;

    private void OnEnable()
    {
        for (int i = 0; i < Amount; i++)
        {
            int index = Random.Range(0, Objects.Length);

            Vector3 position = new Vector3(Random.Range(-10, 10), 
                                           Random.Range(-10, 10), 
                                           Random.Range(-10, 10));

            Instantiate(Objects[index], position, transform.rotation);
        }
    }
}