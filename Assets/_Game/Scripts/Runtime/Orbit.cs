using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float Speed;
    public Transform Center;
    public float Distance;
    public float SurfaceGravity;
    public float OrbitDistance = 10;
    private Transform This;

    private void OnEnable()
    {
        This = transform;
        OrbitDistance = 10;
    }

    public void StartOrbit()
    {
        enabled = true;
        This.SetParent(Center);
        Speed = Random.Range(30, 80);
    }

    void Update()
    {
        This.RotateAround(Center.position, Vector3.up, Speed * Time.deltaTime);

        SetHeight();
        SetDistance();
    }

    public void SetHeight()
    {
        if (Mathf.Abs(This.position.y - Center.transform.position.y) < 0.1f)
        {
            return;
        }
        float y = Mathf.Lerp(This.position.y, Center.transform.position.y, Time.deltaTime);
        This.position = new Vector3(This.position.x, y, This.position.z);
    }

    public void SetDistance()
    {
        Distance = Vector3.Distance(This.position, Center.transform.position);

        if (Distance <= OrbitDistance)
        {
            return;
        }
        float increment = SurfaceGravity * Time.deltaTime;
        This.position = Vector3.MoveTowards(This.position, Center.position, increment);
    }
}