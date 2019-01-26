using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Game
{
    public class WorldGenerator : MonoBehaviour
    {
        public int SimultaneousObjects = 240;
        public float GenerationRadius;

        public float MagnetismDistance = 10f;
        public float MagnetismSpeed = 1f;

        public AssetList CelestialObjects;
        
        private readonly List<Transform> generatedObjects = new List<Transform> (1024);
        private Transform attachedTransform;
        private Transform playerTransform;
        
        private void Start ()
        {
            attachedTransform = transform;
            attachedTransform.hierarchyCapacity = 1024;
            playerTransform = PlayerController.Player.transform;
            
            var origin = attachedTransform.position;
            
            for (var i = 0; i < SimultaneousObjects; i++)
            {
                var position = origin + Random.insideUnitSphere * GenerationRadius;
                var co = Instantiate (CelestialObjects.GetRandom (), position, Quaternion.identity, transform);                
                generatedObjects.Add (co);
            }
        }

        private void Update ()
        {
            var maxDistance = GenerationRadius * GenerationRadius;
            var magnetismDistance = MagnetismDistance * MagnetismDistance;
            var playerPosition = playerTransform.position;
            
            for (var i = generatedObjects.Count - 1; i >= 0; i--)
            {
                var obj = generatedObjects[i];
                var sqrDistance = (obj.position - playerPosition).sqrMagnitude;

                if (sqrDistance > maxDistance)
                {
                    MoveToNewPosition (in playerPosition, obj);
                    continue;
                }

                if (magnetismDistance > sqrDistance)
                {
                    MoveToWards (in playerPosition, obj);
                }        
            }
        }

        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private void MoveToWards (in Vector3 target, Transform obj)
        {
            obj.position = Vector3.MoveTowards (obj.position, target, MagnetismSpeed * Time.deltaTime);
        }
        
        [MethodImpl (MethodImplOptions.AggressiveInlining)]
        private void MoveToNewPosition (in Vector3 center, Transform t)
        {
            t.position = center + Random.onUnitSphere * GenerationRadius;
            t.gameObject.SetActive (true);
        }
    }

}