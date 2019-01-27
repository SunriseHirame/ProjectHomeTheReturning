using UnityEngine;
using Hirame.Minerva;

namespace Game
{
    public class CelestialObject : MonoBehaviour
    {             
        private float fullSizeDistance = 1;
        private float fadeOutDistance = 40;

        public float TumblingSpeed = 10;
        
        public Light TheLight;

        public GameObject CollectionEffect;
        
        private Vector3 targetSize;
        private Quaternion tumble;
        private float lightIntensity;
        
        public EssenceValue[] TargetType;
     
        private PlayerController player;
    
        private Transform attachedTransform;
                
        private void Awake ()
        {
            attachedTransform = transform;
            targetSize = attachedTransform.localScale;
            tumble = Quaternion.Euler (Random.insideUnitSphere * TumblingSpeed);
        }

        private void OnEnable()
        {
            player = PlayerController.Player;
            lightIntensity = TheLight.intensity;
            WorldGenerator.UpdateList.Add (this);
        }

        private void OnDisable ()
        {
            WorldGenerator.UpdateList.Remove (this);
        }

        public void OnUpdate (AnimationCurve scaleCurve)
        {
            var direction = player.AttachedRigidbody.position - attachedTransform.position;
            var sqrDistanceToPlayer = direction.sqrMagnitude;
            
            if (sqrDistanceToPlayer > (fadeOutDistance * fadeOutDistance))
            {
                if (attachedTransform.localScale != Vector3.zero)
                    attachedTransform.localScale = Vector3.zero;
                if (TheLight.intensity != 0)
                    TheLight.intensity = 0;
                return;
            }

            var distanceToPlayer = direction.magnitude;          
            var t = Mathf.Clamp01 ((fadeOutDistance - distanceToPlayer) / fadeOutDistance);

            t = scaleCurve.Evaluate (t);
            attachedTransform.localScale =  Vector3.Lerp (Vector3.zero, targetSize, t);
            TheLight.intensity = Mathf.Lerp (0, lightIntensity, t);

            attachedTransform.rotation *= tumble;
        }

        private void OnTriggerEnter (Collider other)
        {
            for (var i = 0; i < TargetType.Length; i++)
            {
                TargetType[i].Collect ();
            }
            gameObject.SetActive (false);

            if (CollectionEffect != null)
                SpawnCollectionEffect ();
        }

        private void SpawnCollectionEffect ()
        {
            Instantiate (CollectionEffect, attachedTransform.position, attachedTransform.rotation);
        }
        
        [System.Serializable]
        public struct EssenceValue
        {
            public GlobalInt Type;
            public int Value;

            public void Collect ()
            {
                Type.RuntimeValue += Value;
            }
        }
    }

}
