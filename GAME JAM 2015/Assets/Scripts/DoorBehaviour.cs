﻿using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour 
{
    //Audio
    AudioSource doorOpen, doorClose, doorLock;
    /// 
    public float ClosedYRotation = 0;
    public float OpenedYRotation = 90;
    public bool StartOpened = false;
    public float DoorOpenSpeed = 1.0f;
    public bool isLocked = false;

    bool isOpened, isClosed, isClosing, isOpenning;
    float currentYRotation;
    Transform doorTransform;
    Transform player;

    const float DOOR_COOLDOWN = 0.1f;
    float cooldown = 0;
    bool isActionStillPressed = false;

	// Use this for initialization
	void Start () 
    {
        doorOpen = gameObject.transform.FindChild("doorOpen").transform.GetComponent<AudioSource>();
        doorClose = gameObject.transform.FindChild("doorClose").transform.GetComponent<AudioSource>();
        doorLock = gameObject.transform.FindChild("doorLock").transform.GetComponent<AudioSource>();
        isClosing = isOpenning = false;
        isOpened = StartOpened;
        isClosed = !isOpened;
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

	}
	
	// Update is called once per frame
    void Update()
    {
        Ray playerLookRay = new Ray(player.FindChild("Main Camera").position, player.FindChild("Main Camera").forward);
        RaycastHit hitInfo;

        if (isActionStillPressed && Input.GetAxis("Action") <= 0)
            isActionStillPressed = false;

        if (cooldown > 0)
            cooldown -= Time.deltaTime;
        else if (!isLocked)
        {

            try
            {
                //Set Door in motion. If already in motion, set it in other direction.
                if (Input.GetAxis("Action") > 0 && !isActionStillPressed && Vector3.Distance(doorTransform.position, player.position) < 3.5f && doorTransform.FindChild("Door").gameObject.collider.Raycast(playerLookRay, out hitInfo, 10))
                {
                    cooldown = DOOR_COOLDOWN;
                    isActionStillPressed = true;
                    //player.GetComponent<CharacterMotor>().enabled = false;

                    if (isClosing)
                    {
                        isClosing = false;
                        isOpenning = true;
                        doorOpen.Play(); 
                    }
                    else if (isOpenning)
                    {
                        isClosing = true;
                        isOpenning = false;
                        doorOpen.Play(); 
                    }
                    else if (isOpened)
                    {
                        isClosing = true;
                        isOpened = false;
                        doorOpen.Play(); 
                    }
                    else//isClosed
                    {
                        isOpenning = true;
                        isClosed = false;
                        doorOpen.Play(); 
                    }

                }
            }
            catch
            {
                Debug.Log(gameObject.name);
            }
        }  
        else if (Input.GetAxis("Action") > 0 && !isActionStillPressed && Vector3.Distance(doorTransform.position, player.position) < 3.5f && doorTransform.FindChild("Door").gameObject.collider.Raycast(playerLookRay, out hitInfo, 10))
        {
            //play locked sound
            doorLock.Play();
        }

        //check if fully closed/opened; else, continue motion
        if (isClosing)
        {
            if (currentYRotation == ClosedYRotation)
            {
                isClosing = false;
                isClosed = true;
                doorClose.Play();
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

    public void OpenDoor()
    {
        if (!isOpened)
        {
            isOpenning = true;
            isClosing = false;

            isClosed = isClosed ? false : isClosed;
        }
    }

    public void CloseDoor()
    {
        if (!isClosed)
        {
            isClosing = true;
            isOpenning = false;

            isOpened = isOpened ? false : isOpened;
        }
    }

    public void LockDoor()
    {
        isLocked = true;
    }

    public void UnlockDoor()
    {
        isLocked = false;
    }
}
