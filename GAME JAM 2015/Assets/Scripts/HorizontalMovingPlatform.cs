using UnityEngine;
using System.Collections;

public class HorizontalMovingPlatform : MonoBehaviour {
    Transform platform;
    GameObject leftLimit;
    GameObject rightLimit;
    Vector3 hspeed;
    bool stopped;
    bool left = false;
    Transform player;

    // Use this for initialization
    void Start()
    {
        platform = gameObject.transform.FindChild("PlatformH");
        leftLimit = gameObject.transform.FindChild("LeftPoint").gameObject;
        rightLimit = gameObject.transform.FindChild("RightPoint").gameObject;
        hspeed = new Vector3(0, 0, 1);
        stopped = false;
        player = GameObject.Find("First Person Duck Controller").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray playerLookRay = new Ray(player.FindChild("Main Camera").position, player.FindChild("Main Camera").forward);
            RaycastHit hitInfo;

            //checks for raycast hit from player camera
            if (platform.gameObject.collider.Raycast(playerLookRay, out hitInfo, 10))
            {
                //stalls movement if moving
                if (!stopped)
                {
                    Frozen();
                }
                //starts movement if frozen
                else if (stopped)
                {
                    Thawed();
                }
            }
        }

        if (!stopped)
        {
            platform.transform.Translate(Moving(hspeed) / 30.0f);
        }
    }

    Vector3 Moving(Vector3 hspeed)
    {
        if (platform.transform.localPosition.z > leftLimit.transform.localPosition.z && left)
        {
            left = false;
        }
        else if (platform.transform.localPosition.z < rightLimit.transform.localPosition.z && !left)
        {
            left = true;
        }

        if (left)
            return hspeed;
        else
            return -hspeed;
    }

    void Frozen()
    {
        stopped = true;
    }

    void Thawed()
    {
        stopped = false;
    }
}

