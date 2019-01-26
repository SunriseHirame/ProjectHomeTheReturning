using System.Collections;
using System.Collections.Generic;
using Hirame.Minerva;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        public GlobalValueBase[] Globals;

        private void OnEnable ()
        {
            foreach (var global in Globals)
            {
                global.Reset ();
            }
        }
    }

}