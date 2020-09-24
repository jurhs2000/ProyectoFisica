using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private bool state = false;
    public float t;
    public InputField timeDivField;
    public float timeDivisor;

    void Start()
    {
        startTime = Time.time;
        Time.timeScale = 0;
    }
    void Update()
    {
        t = Time.time - startTime;

        string seconds = (t % 60).ToString("f4");
        timerText.text = seconds + " seconds";
        if (timeDivField.text != "0")
            timeDivisor = (float)(1f / float.Parse(timeDivField.text));
        else
            timeDivField.text = "1000";
    }

    public void playTime()
    {
        if (state)
        {
            Time.timeScale = 0;
            state = false;
        } else
        {
            Time.timeScale = timeDivisor;
            state = true;
        }
    }

}