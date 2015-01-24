using UnityEngine;
using System.Collections;

public class ButtonRoomButtons : MonoBehaviour {

    protected Animator animator;
    public GameObject trigger;
    public GameObject door;

    DoorBehaviour doorB;

	// Use this for initialization
	void Start () 
    {
        doorB = door.GetComponent<DoorBehaviour>();
        animator = GetComponent<Animator>();
        animator.SetBool("Pressed", false);
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
            //trigger.GetComponent<Grabbable>().SetUngrabbable();
            animator.SetBool("Pressed", true);

            doorB.OpenDoor();
            doorB.UnlockDoor();

        }
    }

    void OnCollisionExit(Collision col)
    {
        doorB.CloseDoor();
        doorB.LockDoor();
        animator.SetBool("Pressed", false);
    }
}
