using UnityEngine;
using System.Collections;

public class Room_02_Event_Handler : MonoBehaviour {
    
    public GameObject lockedDoor1, lockedDoor2;
    public GameObject wall1, wall2;
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
            lockedDoor1.transform.GetComponent<DoorBehaviour>().OpenDoor();
        else
            lockedDoor1.transform.GetComponent<DoorBehaviour>().CloseDoor();
        if (flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED == 2)
            lockedDoor2.transform.GetComponent<DoorBehaviour>().OpenDoor();
        else
            lockedDoor2.transform.GetComponent<DoorBehaviour>().CloseDoor();
        if (flags.IS_SWITCH_PRESSED == true)
            wall1.transform.GetComponent<MoveableWallBehaviour>().Open();
        else
            wall1.transform.GetComponent<MoveableWallBehaviour>().Close();
        if (flags.IS_BUTTON_03_PRESSED == true)
            wall2.transform.GetComponent<MoveableWallBehaviour>().Open();
        else
            wall2.transform.GetComponent<MoveableWallBehaviour>().Close();
	}
}
