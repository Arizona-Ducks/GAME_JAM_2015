using UnityEngine;
using System.Collections;

public class VerticalMovingPlatform : MonoBehaviour {
    Transform platform;
    GameObject topLimit;
    GameObject bottomLimit;
    Vector3 vspeed;
    bool stopped;
    bool down = false;

    Transform player;

	// Use this for initialization
	void Start () {
        platform = gameObject.transform.FindChild("PlatformV");
        topLimit = gameObject.transform.FindChild("TopPoint").gameObject;
        bottomLimit = gameObject.transform.FindChild("BottomPoint").gameObject;
        vspeed = new Vector3(0, -1, 0);
        stopped = false;
        player = GameObject.Find("First Person Duck Controller").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.DrawRay(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").right);

        if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_FORWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").right);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (gameObject.transform.FindChild("PlatformV").gameObject.collider.Raycast(gunLookRay, out hitInfo, 30))
            {
                Thawed();
            }
        }
        else if (player.transform.FindChild("Main Camera").transform.FindChild("TimeGun").GetComponent<GunBehaviour>().FIRING_BACKWARD)
        {
            Ray gunLookRay = new Ray(player.FindChild("Main Camera").transform.FindChild("TimeGun").position, player.FindChild("Main Camera").transform.FindChild("TimeGun").right);
            RaycastHit hitInfo;

            //checks for raycast hit from gun camera
            if (gameObject.transform.FindChild("PlatformV").gameObject.collider.Raycast(gunLookRay, out hitInfo, 30))
            {
                Frozen();
            }
        }

        if (!stopped)
        {
            platform.transform.Translate(Moving(vspeed) / 15.0f);
        }
	}

    Vector3 Moving(Vector3 vspeed)
    {
        if (platform.transform.localPosition.y > topLimit.transform.localPosition.y && !down)
        {
            down = true;
        }
        else if (platform.transform.localPosition.y < bottomLimit.transform.localPosition.y && down)
        {
            down = false;
        }

        if (down)
            return vspeed;
        else
            return -vspeed;
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
