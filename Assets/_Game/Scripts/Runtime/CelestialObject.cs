using UnityEngine;
using Hirame.Minerva;

namespace Game
{
    public class CelestialObject : MonoBehaviour
    {             
        private float fullSizeDistance = 10;    
        public Light TheLight;

        public GameObject CollectionEffect;
        
        private Vector3 targetSize;
        private float lightIntensity;
        
        public EssenceValue[] TargetType;
     
        private PlayerController player;
    
        private Transform attachedTransform;
        
        private void Awake ()
        {
            attachedTransform = transform;
            targetSize = attachedTransform.localScale;
        }

        private void Start()
        {
            player = PlayerController.Player;
            lightIntensity = TheLight.intensity;
        }

        private void Update ()
        {
            var direction = player.AttachedRigidbody.position - attachedTransform.position;
            var sqrDistanceToPlayer = direction.sqrMagnitude;
            var sqrFullDistance = fullSizeDistance * fullSizeDistance;     
            var t = Mathf.Clamp01 (sqrFullDistance / sqrDistanceToPlayer);   
            
            attachedTransform.localScale =  Vector3.Lerp (Vector3.zero, targetSize, t);
            TheLight.intensity = Mathf.Lerp (0, lightIntensity, t);
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
