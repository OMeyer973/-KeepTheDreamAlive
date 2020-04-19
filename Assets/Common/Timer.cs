using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    private float bestTime;
    private float lastCompleteTime;
    private float currentTime;

    bool timerRunning = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    void Update()
    {
        if (!timerRunning) return;

        currentTime += Time.deltaTime;
        UI.Instance.UpdateTimerDisplay(getCurrentTimeString());
    }

    public void BeginTimer ()
    {
        currentTime = 0;
        timerRunning = true;
    }
    public void PauseTimer ()
    {
        timerRunning = false;
    }

    public void UnpauseTimer ()
    {
        timerRunning = true;
    }

    public float getTime()
    {
        return currentTime;
    }

    public void saveTime()
    {
        timerRunning = false;
        lastCompleteTime = currentTime;
        if (bestTime <= 0 || lastCompleteTime <= bestTime)
        {
            bestTime = lastCompleteTime;
        }
    }
    public string getCurrentTimeString()
    {
        return Mathf.Floor(currentTime / 60).ToString("00") + ":" + (currentTime % 60).ToString("00");
    }
    public string getLastCompleteTimeString()
    {
        return getTimeString(lastCompleteTime);
    }
    public string getBestTimeString()
    {
        return getTimeString(bestTime);
    }
    public string getTimeString(float time)
    {
        if (time <= .1)
        {
            return ("--:--");
        }

        float h = Mathf.Floor(time / 3600f);
        float m = Mathf.Floor((time - h * 3600f) / 60f);
        float s = Mathf.Floor(time - m * 60f);
        float ds = time - s;

        string timeString;
        if (h > .1)
        {
            timeString = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00") + ":" + ds.ToString("N2").Remove(0, 2);
        } else {
            timeString = m.ToString("00") + ":" + s.ToString("00") + ":" + ds.ToString("N2").Remove(0, 2);
        }
        return timeString;
    }
}
