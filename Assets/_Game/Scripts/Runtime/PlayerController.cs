using UnityEngine;

namespace Game
{
    public class PlayerController : MonoBehaviour
    {
        public string Horizontal = "Horizontal";
        public string Vertical = "Vertical";
        public string Forward = "Forward";
        
        public static PlayerController Player;
        
        public float FlySpeed;
        public Rigidbody AttachedRigidbody;
        public Transform MainCamera;

        private Vector3 input;

        private void Awake ()
        {
            Player = this;
        }

        private void Update ()
        {
            input = new Vector3(
                Input.GetAxis (Horizontal),
                Input.GetAxis (Vertical),
                Input.GetAxis (Forward)
                );
        }

        private void FixedUpdate ()
        {
            var direction = MainCamera.TransformDirection (input);
            var frameDistance = direction * FlySpeed * Time.fixedDeltaTime;
            var targetPosition = AttachedRigidbody.position + frameDistance;
 
            AttachedRigidbody.MovePosition (targetPosition);
        }
    }

}