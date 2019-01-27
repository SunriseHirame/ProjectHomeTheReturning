using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image TargetImage;

    public Color TargetColor;
    public float Length = 1;

    public AnimationCurve FadeCurve = AnimationCurve.EaseInOut (0,0,1,1);
    
    private Color startColor;
    private float startTime;
    
    private void OnEnable ()
    {
        startColor = TargetImage.color;
        startTime = Time.time;
    }

    private void Update ()
    {
        var elapsed = Time.time - startTime;
        var t = FadeCurve.Evaluate (Mathf.Clamp01 (elapsed / Length));
        TargetImage.color = Color.Lerp (startColor, TargetColor, t);

        if (elapsed > Length)
            enabled = false;
    }
}
