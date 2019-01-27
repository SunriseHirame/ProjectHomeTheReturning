using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message : MonoBehaviour
{
    public GameObject[] MessageList;
    public float time;
    public float Interval;
    public int index;

    private void OnEnable()
    {
        //index = 0;
    }

    private void Update()
    {
        if (index == 3)
        {
            enabled = false;
            return;
        }

        time += Time.deltaTime;

        if (time >= Interval)
        {
            if (MessageList.Length == index - 1)
            {
                enabled = false;
                return;
            }

            MessageList[index].SetActive(false);
            index++;
            MessageList[index].SetActive(true);
            time = 0;
        }
    }
}