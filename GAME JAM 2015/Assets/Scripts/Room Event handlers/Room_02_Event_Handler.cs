using UnityEngine;
using System.Collections;

public class Room_02_Event_Handler : MonoBehaviour {

    AudioSource finishedSound;
    bool soundPlayed = false;
    bool soundPlayed2 = false;
    public GameObject lockedDoor1, lockedDoor2;
    public GameObject wall1, wall2;
    GLOBAL_FLAGS flags;

    public GameObject clock;
    bool has_2nd_box_spawned = false;
    public Transform boxSpawnPoint;
    public GameObject box;

    // Use this for initialization
    void Start()
    {
        finishedSound = GetComponent<AudioSource>();
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
        flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED = 0;
    }
	
	// Update is called once per frame
	void Update () 
    {
        if (!clock.GetComponent<AnalogClock>().timeRunningFoward && !has_2nd_box_spawned)
        {
            has_2nd_box_spawned = true;
            Instantiate(box, boxSpawnPoint.position, boxSpawnPoint.rotation);
        }

        if (flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED == 1)
        {
            lockedDoor1.transform.GetComponent<DoorBehaviour>().OpenDoor();
            if(!soundPlayed)
                flags.FINISHED_PUZZLE = true;
        }
        else
            lockedDoor1.transform.GetComponent<DoorBehaviour>().CloseDoor();
        if (flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED == 2)
        {
            lockedDoor2.transform.GetComponent<DoorBehaviour>().OpenDoor();
            if(!soundPlayed2)
                flags.FINISHED_PUZZLE = true;
        }
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
        if (flags.FINISHED_PUZZLE)
        {
            if(flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED == 1)
                soundPlayed = true;
            else if(flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED == 2)
                soundPlayed2 = true;
            finishedSound.Play();
            flags.FINISHED_PUZZLE = false;
        }
	}
}
