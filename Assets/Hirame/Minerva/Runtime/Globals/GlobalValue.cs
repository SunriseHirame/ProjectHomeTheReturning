﻿using UnityEngine;

namespace Hirame.Minerva
{
    public abstract class GlobalValue<T> : GlobalValueBase
        where T : unmanaged
    {
        public T InitialValue;
        public T RuntimeValue;

        public override void Reset ()
        {
            RuntimeValue = InitialValue;
        }

        public override string ToString ()
        {
            return RuntimeValue.ToString ();
        }
    }

    public abstract class GlobalValueBase : ScriptableObject
    {
        public abstract void Reset ();
    }

}
