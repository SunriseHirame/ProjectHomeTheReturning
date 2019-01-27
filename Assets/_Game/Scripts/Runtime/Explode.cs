using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
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

        #if UNITY_EDITOR
        [ContextMenu ("Find Rigidbodies")]
        private void FindRigidbodies ()
        {
            attachedRigidbodies = GetComponentsInChildren<Rigidbody> ();
            EditorUtility.SetDirty (this);
        }
        #endif
    }

}