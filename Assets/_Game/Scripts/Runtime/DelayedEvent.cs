using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class DelayedEvent : MonoBehaviour
    {
        public bool FireOnEnable;
        public float Delay = 1f;

        public UnityEvent Event;
            
        private void OnEnable ()
        {
            if (FireOnEnable)
                SendEvent (Delay);
        }

        public void SendEvent (float delay)
        {
            Invoke (nameof (SendEvent), Delay);
        }

        private void SendEvent ()
        {
            Event.Invoke ();
        }
    }

}