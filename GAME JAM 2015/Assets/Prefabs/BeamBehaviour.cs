using UnityEngine;
using System.Collections;

public class BeamBehaviour : MonoBehaviour {

    public bool Alive = true;
    public float TimeTilDeath = 1.33f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (TimeTilDeath > 0)
        {
            TimeTilDeath -= Time.deltaTime;
        }
        else
            Alive = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Foward")
            Alive = false;
    }
}
