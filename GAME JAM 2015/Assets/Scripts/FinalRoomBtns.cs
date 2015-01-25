using UnityEngine;
using System.Collections;

public class FinalRoomBtns : MonoBehaviour {

    GLOBAL_FLAGS flags;
    //GameObject spawnRm08;
    //GameObject spawnRm01;
    GameObject lockedDoor;

    protected Animator animator;

	// Use this for initialization
	void Start () {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
        //spawnRm01 = GameObject.Find("To Room_01");
        //spawnRm08 = GameObject.Find("To Room_08");
        lockedDoor = GameObject.Find("LockedDoor00");
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
            //Update globalFlags
            flags.FINAL_ROOM_BUTTON_PRESSED = true;
            animator.SetBool("Pressed", true);
            lockedDoor.transform.GetComponent<DoorBehaviour>().UnlockDoor();
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Button Trigger")
        {
            flags.FINAL_ROOM_BUTTON_PRESSED = false;
            animator.SetBool("Pressed", false); 
            lockedDoor.transform.GetComponent<DoorBehaviour>().LockDoor();
        }
    }
}