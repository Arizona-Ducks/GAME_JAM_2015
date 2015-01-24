using UnityEngine;
using System.Collections;

public class ButtonRoomButtons : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Button Trigger")
        {
            Debug.Log("Button Pressed!");
        }
    }
}
