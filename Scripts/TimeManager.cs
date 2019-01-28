using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    private float startTime = 0;
    public float StartTime { get { return startTime; } }
    private float endTime = 0;

    public void SetStartTime()
    {
            startTime = Time.time;
    }

    public void SetEndTime()
    {
        endTime = Time.time;
    }

    public float GetFinalTime()
    {
         return endTime - startTime;
    }



}
