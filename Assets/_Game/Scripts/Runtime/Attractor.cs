using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float Orbitals;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Orbit>())
        {
            other.gameObject.GetComponent<Orbit>().StartOrbit();
            Orbitals++;
        }
    }
}