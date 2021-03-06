﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Utilities : MonoBehaviour {

    public static void SlerpTransform(Transform objectToLerp, Transform start, Transform target, float fracJourney)
    {

        objectToLerp.position = Vector3.Slerp(start.position, target.position, fracJourney);

        objectToLerp.rotation = Quaternion.Slerp(start.rotation, target.rotation, fracJourney);
    }

    public static void LerpTransform(Transform objectToLerp, Transform start, Transform target, float fracJourney)
    {
        objectToLerp.position = Vector3.Lerp(start.position, target.position, fracJourney);
        objectToLerp.rotation = Quaternion.Lerp(start.rotation, target.rotation, fracJourney);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
    }


    
}
