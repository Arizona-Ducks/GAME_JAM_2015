using UnityEngine;
using System.Collections;

public class Room_02_Event_Handler : MonoBehaviour {
    
    public GameObject LockedDoor1;
    GLOBAL_FLAGS flags;

    // Use this for initialization
    void Start()
    {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
        flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED = 0;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED == 1)
        {
            LockedDoor1.transform.GetComponent<DoorBehaviour>().OpenDoor();
        }
        else
        {
            LockedDoor1.transform.GetComponent<DoorBehaviour>().CloseDoor();
        }
	}
}
