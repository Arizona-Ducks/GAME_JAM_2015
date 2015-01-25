using UnityEngine;
using System.Collections;

public class Room_04_Event_Handler : MonoBehaviour {

    GLOBAL_FLAGS flags;
    public GameObject locked_door;
    public GameObject clock;
    public GameObject phonograph;
    AudioSource finishedSound;
    bool soundPlayed = false;

    bool finishedPuzzle = false;

	// Use this for initialization
	void Start () {
        finishedSound = GetComponent<AudioSource>();
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();

        if (flags.ROOM_04_PUZZLE_FINISHED)
        {
            locked_door.GetComponent<DoorBehaviour>().UnlockDoor();
            phonograph.GetComponent<Phonograph>().ChangeTimeDirectionToFoward();
            clock.GetComponent<AnalogClock>().ChangeTimeDirectionToFoward();
            finishedPuzzle = true;
        }

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!finishedPuzzle)
        {
            if (clock.GetComponent<AnalogClock>().timeRunningFoward)
                flags.ROOM_04_PUZZLE_FINISHED = true;

            if (flags.ROOM_04_PUZZLE_FINISHED)
            {
                if (!phonograph.GetComponent<Phonograph>().isNorm)
                {
                    phonograph.GetComponent<Phonograph>().ChangeTimeDirectionToFoward();
                }
                finishedPuzzle = true;
                locked_door.GetComponent<DoorBehaviour>().UnlockDoor();
                locked_door.GetComponent<DoorBehaviour>().OpenDoor();
                flags.FINISHED_PUZZLE = true;
            }
            if (flags.FINISHED_PUZZLE && !soundPlayed)
            {
                soundPlayed = true;
                finishedSound.Play();
                flags.FINISHED_PUZZLE = false;
            }
        }
	}
}
