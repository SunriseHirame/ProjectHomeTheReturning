using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitAnyKey : MonoBehaviour
{
    public UnityEvent Event;
    
    private void Update ()
    {
        if (Input.anyKeyDown)
        {
            Event.Invoke ();
            enabled = false;
        }
    }
}
