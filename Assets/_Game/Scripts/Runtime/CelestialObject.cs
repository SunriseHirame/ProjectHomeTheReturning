using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using Hirame.Minerva;

namespace Game
{
    public class CelestialObject : MonoBehaviour
    {
        public GlobalInt TargetType;
        
        public float FullSizeDistance;    
        public Light TheLight;
        
        private Vector3 targetSize;
        private float lightIntensity;
    
        private PlayerController player;
    
        private Transform attachedTransform;
        
        private void Start ()
        {
            attachedTransform = transform;
            targetSize = attachedTransform.localScale;
            player = PlayerController.Player;
            lightIntensity = TheLight.intensity;
        }
    
        private void Update ()
        {
            var direction = player.AttachedRigidbody.position - attachedTransform.position;
            var sqrDistanceToPlayer = direction.sqrMagnitude;
            var sqrFullDistance = FullSizeDistance * FullSizeDistance;     
            var t = Mathf.Clamp01 (sqrFullDistance / sqrDistanceToPlayer);   
            
            attachedTransform.localScale =  Vector3.Lerp (Vector3.zero, targetSize, t);
            TheLight.intensity = Mathf.Lerp (0, lightIntensity, t);
        }

        private void OnTriggerEnter (Collider other)
        {
            TargetType.RuntimeValue += 1;
            gameObject.SetActive (false);
        }
    }

}
