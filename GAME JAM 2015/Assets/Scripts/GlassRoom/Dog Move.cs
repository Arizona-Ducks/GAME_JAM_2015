using UnityEngine;
using System.Collections;

public class DogMove : MonoBehaviour {

    public  Vector3 velocity = new Vector3(100.0f,0.0f,0.0f);
    public Vector3 acceleration= new Vector3(5.0f,0.0f,0.0f);
    public Vector3 position;
	// Use this for initialization
	
        void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Button Trigger")
        {
            velocity *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {

        float timestep = 1;
        ///update velocity and do the wall collisions here


        position = new Vector3(0.5f * acceleration.x * timestep * timestep, -9.8f, 0.5f * acceleration.z * timestep * timestep);



        rigidbody.position += velocity;
        
	}
}
