using Hirame.Minerva;
using UnityEngine;

namespace Game
{
    public class PlayerEssence : MonoBehaviour
    {
        public Color DefaultColor = Color.white;
        public int FullColorAmount = 100;

        public Light PlayerLight;
        
        public EssenceColor[] EssenceColors;

        private void Awake ()
        {
            PlayerLight.color = DefaultColor;
        }

        private void Update ()
        {
            var targetColor = DefaultColor;
            var total = 0;
            
            for (var i = 0; i < EssenceColors.Length; i++)
            {
                targetColor = EssenceColors[i].GetBlendedColor (targetColor, FullColorAmount);
            }
            
            PlayerLight.color = targetColor;
        }

        [System.Serializable]
        public struct EssenceColor
        {
            public GlobalInt Type;
            public Color Color;

            public Color GetBlendedColor (in Color color, float full)
            {
                return Color.Lerp (color, Color, Type.RuntimeValue / full);
            }
        }
    }

}
