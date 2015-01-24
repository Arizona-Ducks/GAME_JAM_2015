using UnityEngine;
using System.Collections;

public class ButtonRoomButtons : MonoBehaviour {

    GLOBAL_FLAGS flags;

    protected Animator animator;

	// Use this for initialization
	void Start () 
    {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();

        animator = GetComponent<Animator>();
        animator.SetBool("Pressed", false);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Button Trigger")
        {
            //Update globalflags
            flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED++;

            animator.SetBool("Pressed", true);

        }
    }

    void OnCollisionExit(Collision col)
    {
        //Update globalflags
        flags.NUMBER_OF_ROOM_02_BUTTONS_PRESSED--;
        animator.SetBool("Pressed", false);
    }
}
