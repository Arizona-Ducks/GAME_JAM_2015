using UnityEngine;
using System.Collections;

public class ButtonRoomButtons : MonoBehaviour {

    public GameObject trigger;
    public GameObject door;

    DoorBehaviour doorB;

	// Use this for initialization
	void Start () 
    {
        doorB = door.GetComponent<DoorBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Button Trigger")
        {
            //disable trigger script grabbable
            //open door
            trigger.GetComponent<Grabbable>().SetUngrabbable();

            doorB.OpenDoor();
            doorB.UnlockDoor();

        }
    }
}
