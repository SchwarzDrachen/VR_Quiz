using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] float maxTime = 60f;
    [SerializeField] float currentTime = 60f;
    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField]public UnityEvent onGameTimerEnd;

    public bool timerRuns = false;
    private bool TimerEnabled = false;

    public void Start()
    {
        currentTime = maxTime;
    }
    public void ResetTime(){
        currentTime = maxTime;
        timerRuns = true;
        StopTimer();
    }
    public void Update()
    {
        if (TimerEnabled == true){
            currentTime -= Time.deltaTime;
        }
        if(currentTime <= 0 && TimerEnabled == true){
            onGameTimerEnd?.Invoke();
            Debug.LogWarning("Timer Ended");
            TimerEnabled = false;
            currentTime = 0;
        }

        DisplayTime(currentTime);
    }

    void DisplayTime(float t){
        int min = (int)t/60;
        int sec = (int)t%60;
        Debug.Log($"minutes{min}");
        Debug.Log($"seconds{sec}");

        timeText.text = string.Format("{0:00}:{1:00}",min,sec);
    }
    public void StartTimer(){
        TimerEnabled = true;
    }
    public void StopTimer(){
        TimerEnabled = false;
    }
}
