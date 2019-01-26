using System.Collections;
using System.Collections.Generic;
using Hirame.Minerva;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public EssenceTarget[] Target;
        public GlobalValueBase[] Globals;

        private void OnEnable ()
        {
            foreach (var global in Globals)
            {
                global.Reset ();
            }
        }

        private void Update ()
        {
            for (var i = 0; i < Target.Length; i++)
            {
                if (Target[i].IsCompleted () == false)
                    return;
            }

            WinGame ();
        }

        private void WinGame ()
        {
            Debug.Log ("WIN");
        }

        [System.Serializable]
        public struct EssenceTarget
        {
            public int TargetAmount;
            public GlobalInt EssenceStore;

            public bool IsCompleted ()
            {
                return TargetAmount >= EssenceStore.RuntimeValue;
            }
        }
    }

}