using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    public float Orbitals;

    [UnityEngine.Serialization.FormerlySerializedAs ("Settings")]
    public Settings Things;

    public static Transform AttachedTransform;

    public static List<Orbit> Orbiters = new List<Orbit>(1024);

    private void Awake()
    {
        AttachedTransform = transform;
    }

    private void Update()
    {
        Things.DeltaTime = Time.deltaTime;
        Things.Position = AttachedTransform.position;

        foreach (var orbiter in Orbiters)
        {
            orbiter.OnUpdate(in Things);
        }
    }

    [System.Serializable]
    public struct Settings
    {
        public float DeltaTime;
        public float ScalingSpeed;
        public float ConvergenceSpeed;
        public Vector3 Position;
    }
}