using UnityEngine;
using System.Collections;

public class FinalRoomBtns : MonoBehaviour {

    GLOBAL_FLAGS flags;
    GameObject spawnRm08;
    GameObject spawnRm01;

    protected Animator animator;

	// Use this for initialization
	void Start () {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
        Debug.Log(flags);
        spawnRm01 = GameObject.Find("To Room_01");
        Debug.Log(spawnRm01);
        spawnRm08 = GameObject.Find("To Room_08");
        Debug.Log(spawnRm08);
        animator = GetComponent<Animator>();
        Debug.Log(animator);
        animator.SetBool("Pressed", false);
        //Debug.Log(animator.GetBool);
	}
	
	// Update is called once per frame
	void Update () {
        if (!flags.FINAL_ROOM_BUTTON_PRESSED)
        {
            Debug.Log("haventswitchspawn");
            spawnRm08.gameObject.SetActive(true);
            spawnRm01.gameObject.SetActive(false);
        }else if(flags.FINAL_ROOM_BUTTON_PRESSED){
            spawnRm08.gameObject.SetActive(true);
            spawnRm01.gameObject.SetActive(false);
        }
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
