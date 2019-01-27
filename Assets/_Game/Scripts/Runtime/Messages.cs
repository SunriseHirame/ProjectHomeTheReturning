using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public Text text;
    public CanvasGroup canvasGroup;
    public float alpha;
    public float target;

    [TextArea]
    public string[] MessageList;

    private void OnEnable()
    {
        alpha = canvasGroup.alpha;
        //canvasGroup.alpha = 1;
        StartCoroutine(ChangeAlpha(1));
    }

    public void Update()
    {
        //canvasGroup.alpha = Mathf.Lerp(alpha, 1, Time.deltaTime);
    }

    public void NextMessage()
    {

    }

    public IEnumerator ChangeAlpha(float targetAlpha)
    {
        while (alpha != canvasGroup.alpha)
        {
            float time = Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(alpha, targetAlpha, time);

            yield return null;
        }
    }
}