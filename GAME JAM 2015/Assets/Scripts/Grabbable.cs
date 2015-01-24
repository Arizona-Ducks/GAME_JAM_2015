using UnityEngine;
using System.Collections;

public class Grabbable : MonoBehaviour {

    Transform player;
    bool isGrabbed = false;

    bool canGrab = true;
    const float GRAB_COOLDOWN = 0.1f;
    float cooldown = 0;
    bool isActionStillPressed = false;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.Find("First Person Duck Controller").transform;
        //Debug.Log("Grabbable started!");
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.DrawRay(player.FindChild("Main Camera").position, player.FindChild("Main Camera").forward);

        if (canGrab)
        {
            if (isActionStillPressed && Input.GetAxis("Action") <= 0)
                isActionStillPressed = false;

            if (cooldown > 0)
                cooldown -= Time.deltaTime;
            else
            {
                Ray playerLookRay = new Ray(player.FindChild("Main Camera").position, player.FindChild("Main Camera").forward);
                RaycastHit hitInfo;

                //if (gameObject.collider.Raycast(playerLookRay, out hitInfo, 10))
                //    Debug.Log("Looking at ball!");

                //"Grab" object, setting position in fron t of player and adding it as child. removing parent when letting go.
                if (Input.GetAxis("Action") > 0 && !isActionStillPressed)
                {
                    cooldown = GRAB_COOLDOWN;
                    isActionStillPressed = true;


                    if (isGrabbed)
                    {
                        isGrabbed = false;

                        gameObject.transform.parent = null;
                        gameObject.rigidbody.useGravity = true;
                    }
                    else if (Vector3.Distance(gameObject.transform.position, player.position) < 3.5f && gameObject.collider.Raycast(playerLookRay, out hitInfo, 10))
                    {
                        isGrabbed = true;

                        gameObject.transform.parent = player.FindChild("Main Camera");
                        gameObject.transform.Translate(0.2f - gameObject.transform.localPosition.x, 0 - gameObject.transform.localPosition.y, 1.5f - gameObject.transform.localPosition.z, player.FindChild("Main Camera"));
                        gameObject.rigidbody.useGravity = false;

                    }
                }
            }

            if (isGrabbed)
            {
                gameObject.transform.Translate(0.2f - gameObject.transform.localPosition.x, 0 - gameObject.transform.localPosition.y, 1.5f - gameObject.transform.localPosition.z, player.FindChild("Main Camera"));
                gameObject.transform.rotation = player.FindChild("Main Camera").transform.rotation * new Quaternion(-0.258819045f, 0, 0, 0.965925826f);
            }
        }
        else
        {
            isGrabbed = false;
            gameObject.transform.parent = null;
            gameObject.rigidbody.useGravity = true;
        }
	}

    public void SetGrabbable()
    {
        canGrab = true;
    }

    public void SetUngrabbable()
    {
        canGrab = false;
    }
}
