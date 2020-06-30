using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagerUI : MonoBehaviour
{
    public Text remainingTimeText;

    public float frequency = 0.5f;

    private float nextToggle;

    // Update is called once per frame
    void Update()
    {
        if(!TimeManager.instance.isRunning)
        {
            nextToggle -= Time.deltaTime;
            if (nextToggle < 0f)
            {
                remainingTimeText.enabled = !remainingTimeText.enabled;
                nextToggle = frequency;
            }
        }
        else
        {
            remainingTimeText.enabled = true;
        }

        float remainingTime = TimeManager.instance.RemainingTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        string remainingTimeString = minutes.ToString() + ":" + seconds.ToString("D2");

        remainingTimeText.text = remainingTimeString;
    }
}
