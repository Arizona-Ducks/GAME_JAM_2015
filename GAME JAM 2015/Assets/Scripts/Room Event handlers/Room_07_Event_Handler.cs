using UnityEngine;
using System.Collections;

public class Room_07_Event_Handler : MonoBehaviour 
{
    AudioSource finishedSound;
    int score = 0;
    DoorBehaviour door;
    int numNotes;
    int[] noteID;
    float[] delays;
    float[] delayStorage;
    float totalDelay;
    NoteButton[] buttons;

    GLOBAL_FLAGS flags;

	// Use this for initialization
	void Start () 
    {
        finishedSound = GetComponent<AudioSource>();
        door = GameObject.Find("LockedDoor").GetComponent<DoorBehaviour>();
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
        numNotes = Random.Range(5, 7);
        noteID = new int[numNotes];
        delays = new float[numNotes];
        delayStorage = new float[numNotes];
        buttons = new NoteButton[4];
        buttons[0] = GameObject.Find("Button1").GetComponent<NoteButton>();
        buttons[1] = GameObject.Find("Button2").GetComponent<NoteButton>();
        buttons[2] = GameObject.Find("Button3").GetComponent<NoteButton>();
        buttons[3] = GameObject.Find("Button4").GetComponent<NoteButton>();
        for (int i = 0; i < numNotes; ++i)
        {
            noteID[i] = Random.Range(0, 4);
            int tmp = Random.Range(0, 2);
            switch(tmp)
            {
                case 0:
                     if (i > 0)
                        delayStorage[i] = 1f + delayStorage[i - 1];
                    else
                        delayStorage[i] = 7;
                break;
                case 1:
                if (i > 0)
                    delayStorage[i] = 0.5f + delayStorage[i - 1];
                else
                    delayStorage[i] = 6.5f;
                break;

            }
            delays[i] = delayStorage[i];
            totalDelay += delays[i];
        }
	}

    // Update is called once per frame
    void Update() 
    {
        if (flags.HAS_PATTERN_PLAYED == false)//If pattern isnt playing and hasnt been played yet then play it once
        {
            PlayPattern();
            if (delays[numNotes - 1] <= 0) //if last delay is 0 then all the notes have played
                flags.HAS_PATTERN_PLAYED = true;
        }

        //If a button is pressed check if its the right one
        if (flags.NOTE_PRESSED != 0)
        {
            if (noteID[score] == flags.NOTE_PRESSED - 1 && score < numNotes)
                score++;
            else if (noteID[score] != flags.NOTE_PRESSED - 1)
                score = 0;
            flags.NOTE_PRESSED = 0;
        }

        if (score == numNotes - 1)
        {
            flags.FINISHED_PUZZLE = true;
            door.isLocked = false;
            door.OpenDoor();
        }
        if (flags.FINISHED_PUZZLE)
        {
            finishedSound.Play();
            flags.FINISHED_PUZZLE = false;
        }
	}

    void PlayPattern()
    {
        for (int i = 0; i < numNotes; ++i)
        {
            if (delays[i] > 0)
            {
                delays[i] -= Time.deltaTime;
            }
            else
            {
                delays[i] = delayStorage[i] + totalDelay;
                buttons[noteID[i]].Play();
            }
        }
    }
}
