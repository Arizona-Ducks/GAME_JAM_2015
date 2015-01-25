using System;
using UnityEngine;
using System.Collections;

public class AnalogClock : MonoBehaviour 
{
    public Transform secondsPivot;
    public Transform minutesPivot;
    public Transform hoursPivot;

    public bool StartsInReverse = false;

    bool timeRunningFoward;
    public int timeSpeed = 1;
    DateTime currentTime;
    Transform player;

    void Start()
    {
        player = GameObject.Find("First Person Duck Controller").transform;
        currentTime = DateTime.Now;
        timeRunningFoward = !StartsInReverse;
    }

	void Update () 
    {
        if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_FORWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").right);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (gameObject.transform.FindChild("Clock-Face").gameObject.collider.Raycast(gunLookRay, out hitInfo, 30))
            {
                ChangeTimeDirectionToFoward();
            }
        }
        else if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_BACKWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").right);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (gameObject.transform.FindChild("Clock-Face").gameObject.collider.Raycast(gunLookRay, out hitInfo, 30))
            {
                ChangeTimeDirectionToReverse();
            }
        }


        if (timeRunningFoward)
        {
            currentTime = currentTime.AddSeconds(Time.fixedDeltaTime * timeSpeed);
        }
        else
        {
            currentTime = currentTime.AddSeconds(Time.fixedDeltaTime * -timeSpeed);
            Debug.Log(currentTime);
        }

        float seconds = (float)currentTime.Second;
        float minutes = (float)currentTime.Minute;
        float hours = (float)currentTime.Hour;

        float angleSeconds = -360 * (seconds / 60);
        float angleMinutes = -360 * (minutes / 60);
        float angleHours = -360 * (hours / 12);

        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, angleSeconds);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, angleMinutes);
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, angleHours);

	}

    public void ChangeTimeDirectionToFoward()
    {
        timeRunningFoward = true;
    }

    public void ChangeTimeDirectionToReverse()
    {
        timeRunningFoward = false;
    }
}
