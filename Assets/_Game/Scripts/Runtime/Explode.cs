using UnityEditor;
using UnityEngine;

namespace Game
{
    public class Explode : MonoBehaviour
    {
        public float ExplosiveForce = 300f;

        public Rigidbody[] attachedRigidbodies;
        
        private void OnEnable ()
        {
            var position = PlayerController.Player.transform.position;
            foreach (var rb in attachedRigidbodies)
            {
                rb.AddExplosionForce (ExplosiveForce, position, 15f);
            }
        }

        [ContextMenu ("Find Rigidbodies")]
        private void FindRigidbodies ()
        {
            attachedRigidbodies = GetComponentsInChildren<Rigidbody> ();
            EditorUtility.SetDirty (this);
        }
    }

}