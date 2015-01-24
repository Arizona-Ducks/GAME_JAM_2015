using UnityEngine;
using System.Collections;

public class Room_01_Event_Handler : MonoBehaviour {

    public GameObject Note;
    GLOBAL_FLAGS flags;

	// Use this for initialization
	void Start () 
    {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();

            if (flags.IS_THE_NOTE_MISSING)
                Note.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
}
