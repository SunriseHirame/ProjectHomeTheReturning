using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class Orbit : MonoBehaviour
{
    public float Speed;
    private float Distance;
    public float SurfaceGravity;
    public float OrbitDistance = 10;

    private Transform attachedTransform;
    private Rigidbody rb;
    private Vector3 startVelocity;
    private Vector3 targetScale;

    private void OnEnable()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startVelocity = rb.velocity;

        attachedTransform = transform;
        targetScale = attachedTransform.localScale * 0.2f;

        Attractor.Orbiters.Add(this);
        attachedTransform.SetParent(Attractor.AttachedTransform);
        Speed = Random.Range(30, 80);

        OrbitDistance = 10;
    }

    public void OnUpdate (in Attractor.Settings settings)
    {
        float deltaTime = settings.DeltaTime;

        float scalingSpeed = deltaTime * settings.ScalingSpeed;

        attachedTransform.localScale = Vector3.Lerp(attachedTransform.localScale, 
                                                    targetScale, scalingSpeed);

        if (rb.velocity.magnitude > 0.0f)
        {
            float slowingSpeed = deltaTime * settings.ConvergenceSpeed;
            rb.velocity = Vector3.Lerp(startVelocity, Vector3.zero, slowingSpeed);
        }
        else
        {
            rb.isKinematic = true;
        }

        attachedTransform.RotateAround(settings.Position, Vector3.up, Speed * deltaTime);

        SetHeight(in settings);
        SetDistance(in settings);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetHeight(in Attractor.Settings settings)
    {
        if (Mathf.Abs(attachedTransform.position.y - settings.Position.y) < 0.1f)
        {
            return;
        }
        float y = Mathf.Lerp(attachedTransform.position.y, settings.Position.y, settings.DeltaTime);
        attachedTransform.position = new Vector3(attachedTransform.position.x, y, attachedTransform.position.z);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void SetDistance(in Attractor.Settings settings)
    {
        Distance = Vector3.Distance(attachedTransform.position, settings.Position);

        if (Distance <= OrbitDistance)
        {
            return;
        }
        float increment = SurfaceGravity * settings.DeltaTime;
        attachedTransform.position = Vector3.MoveTowards(attachedTransform.position, settings.Position, increment);
    }
}