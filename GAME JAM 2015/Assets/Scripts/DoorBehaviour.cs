﻿using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour 
{
    public float ClosedYRotation = 0;
    public float OpenedYRotation = 90;
    public bool StartOpened = false;
    public float DoorOpenSpeed = 1.0f;

    bool isOpened, isClosing, isOpenning;
    float currentYRotation;
    Transform doorTransform;
    Transform player;

    const float DOOR_COOLDOWN = 0.1f;
    float cooldown = 0;
    bool isActionStillPressed = false;

	// Use this for initialization
	void Start () 
    {
        isClosing = isOpenning = false;
        isOpened = StartOpened;
        doorTransform = gameObject.transform;

        if (StartOpened)
        {
            doorTransform.Rotate(0, OpenedYRotation, 0);
            currentYRotation = OpenedYRotation;
        }
        else
        {
            doorTransform.Rotate(0, ClosedYRotation, 0);
            currentYRotation = ClosedYRotation;
        }

        player = GameObject.Find("First Person Duck Controller").transform;
        //Debug.Log(player);

	}
	
	// Update is called once per frame
    void Update()
    {
        if (isActionStillPressed && Input.GetAxis("Action") <= 0)
            isActionStillPressed = false;

        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else
        {
            Ray playerLookRay = new Ray(player.position, player.forward);
            RaycastHit hitInfo;
            //Debug.DrawRay(player.position, player.forward);

            //Set Door in motion. If already in motion, set it in other direction.
            if (Input.GetAxis("Action") > 0 && !isActionStillPressed  && Vector3.Distance(doorTransform.position, player.position) < 3.5f 
                && doorTransform.FindChild("Door").gameObject.collider.Raycast(playerLookRay, out hitInfo, 10))
            {
                Debug.Log(Vector3.Distance(doorTransform.position, player.position));

                cooldown = DOOR_COOLDOWN;
                isActionStillPressed = true;
                //player.GetComponent<CharacterMotor>().enabled = false;

                if (isClosing)
                {
                    isClosing = false;
                    isOpenning = true;
                }
                else if (isOpenning)
                {
                    isClosing = true;
                    isOpenning = false;
                }
                else if (isOpened)
                {
                    isClosing = true;
                    isOpened = false;
                }
                else//isClosed
                {
                    isOpenning = true;
                }

            }

            //check if fully closed/opened; else, continue motion
            if (isClosing)
            {
                if (currentYRotation == ClosedYRotation)
                {
                    isClosing = false;
                    isOpened = false;
                    //player.GetComponent<CharacterMotor>().enabled = true;
                }
                else
                {
                    //if door is too close to player
                    if (Vector3.Distance(doorTransform.FindChild("Door").transform.position, player.position) <= 1.25f)
                    {
                    }
                    else
                    {
                        if (currentYRotation - DoorOpenSpeed < ClosedYRotation)
                        {
                            doorTransform.Rotate(0, -(currentYRotation - ClosedYRotation), 0);
                            currentYRotation = ClosedYRotation;
                        }
                        else
                        {
                            doorTransform.Rotate(0, -DoorOpenSpeed, 0);
                            currentYRotation -= DoorOpenSpeed;
                        }
                    }
                }
            }
            else if (isOpenning)
            {
                if (currentYRotation == OpenedYRotation)
                {
                    isOpenning = false;
                    isOpened = true;
                    //player.GetComponent<CharacterMotor>().enabled = true;
                }
                else
                {
                    //if door is too close to player
                    if (Vector3.Distance(doorTransform.FindChild("Door").transform.position, player.position) <= 1.25f)
                    {
                    }
                    else
                    {
                        if (currentYRotation + DoorOpenSpeed > OpenedYRotation)
                        {
                            doorTransform.Rotate(0, (OpenedYRotation - currentYRotation), 0);
                            currentYRotation = OpenedYRotation;
                        }
                        else
                        {
                            doorTransform.Rotate(0, DoorOpenSpeed, 0);
                            currentYRotation += DoorOpenSpeed;
                        }
                    }

                }
            }
        }
    }
}
