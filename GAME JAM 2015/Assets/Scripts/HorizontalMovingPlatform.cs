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
        if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_FORWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").forward);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (platform.gameObject.collider.Raycast(gunLookRay, out hitInfo, 10))
            {
                Thawed();
            }
        }
        else if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_BACKWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").forward);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (platform.gameObject.collider.Raycast(gunLookRay, out hitInfo, 10))
            {
                Frozen();
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

