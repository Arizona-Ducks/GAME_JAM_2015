using System;
using UnityEngine;
using System.Collections;

public class AnalogClock : MonoBehaviour 
{
    public Transform secondsPivot;
    public Transform minutesPivot;
    public Transform hoursPivot;

	void Update () 
    {
        DateTime time = DateTime.Now;
        float seconds = (float)time.Second;
        float minutes = (float)time.Minute;
        float hours = (float)time.Hour;

        float angleSeconds = -360 * (seconds / 60);
        float angleMinutes = -360 * (minutes / 60);
        float angleHours = -360 * (hours / 12);

        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, angleSeconds);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, angleMinutes);
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, angleHours);
	}
}
