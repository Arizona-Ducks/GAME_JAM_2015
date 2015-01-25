using UnityEngine;
using System.Collections;

public class MoveableWallBehaviour : MonoBehaviour 
{
    Vector3 oldpos, newpos;
	// Use this for initialization
	void Start () 
    {
        oldpos = gameObject.transform.position;
        newpos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 5, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void Open()
    {
        gameObject.transform.position = Vector3.Lerp(oldpos, newpos, 1f);
    }

    public void Close()
    {
        gameObject.transform.position = Vector3.Lerp(newpos, oldpos, 1f);
    }
}
