using UnityEngine;
using System.Collections;

public class Plate : MonoBehaviour {

    //Vector3 velocity;
    //Vector3 acceleration;
    //Vector3 position;
    //Vector3 force;
    GameObject Ducks;
    bool IsPressureOn = false;
    
    //int timestep = 1;
	// Use this for initialization
    void Start()
    {
        
        //velocity = new Vector3(Random.Range(1.0f, 2.0f), Random.Range(3.0f, 5.0f), 0.0f);
       // acceleration = new Vector3(1.0f,0.0f,0.0f);
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            IsPressureOn = true;
        }
        while (IsPressureOn)
        {
            transform.FindChild("DUCK").gameObject.transform.Rotate(Random.Range(90, 360), Random.Range(90, 360), Random.Range(90, 360));
            transform.FindChild("DUCK").gameObject.rigidbody.AddForce(Random.Range(-1, 1),Random.Range(5000, 1000), 0.0f);
        }
	}
	
	// Update is called once per frame
	void Update () {

     
        
	}
}
