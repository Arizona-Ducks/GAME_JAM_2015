using UnityEngine;
using System.Collections;

public class FinalRoomBtns : MonoBehaviour {

    GLOBAL_FLAGS flags;

    protected Animator animator;

	// Use this for initialization
	void Start () {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();

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
            flags.IS_THE_NOTE_MISSING = true;
            animator.SetBool("Pressed", true);
        }
    }
    void OnCollisionExit(Collision col)
    {
        flags.FINAL_ROOM_BUTTON_PRESSED = false;
        flags.IS_THE_NOTE_MISSING = false;
        animator.SetBool("Pressed", false);
    }
}
