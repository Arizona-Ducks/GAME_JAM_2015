using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour 
{
    GLOBAL_FLAGS flags;
    public bool FIRING_FORWARD = false;
    public bool FIRING_BACKWARD = false;

    protected Animator animator;
    bool HasFoundTimeGun = false;

    public GameObject FowardBeam;
    public GameObject ReverseBeam;
    GameObject[] shots;
    bool[] shotsAlive;
    float speed = 1;

	// Use this for initialization
	void Start () 
    {
        shots = new GameObject[1000];
        shotsAlive = new bool[1000];
        for (int i = 0; i < 1000; i++)
            shotsAlive[i] = false;

        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();

        animator = GetComponent<Animator>();
        animator.SetBool("Shoot", false);

        //hide gun
        gameObject.transform.Translate(0, -10, 0);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!HasFoundTimeGun)
        {
            if (flags.HAS_PICKUP_THE_GUN)
            {
                HasFoundTimeGun = true;

                //pull out time gun
                gameObject.transform.Translate(0, 10, 0);
            }

        }
        else
        {
            if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    FIRING_BACKWARD = false;
                    FIRING_FORWARD = true;
                    //Debug.Log("FIRING_FORWARD :" + FIRING_FORWARD);

                    for (int i = 0; i < 1000; i++)
                    {
                        if (!shotsAlive[i])
                        {
                            shots[i] = Instantiate(FowardBeam, gameObject.transform.position, GameObject.Find("First Person Duck Controller").transform.FindChild("Main Camera").transform.rotation) as GameObject;
                            shots[i].transform.SetParent(GameObject.Find("First Person Duck Controller").transform.FindChild("Main Camera").transform);
                            shotsAlive[i] = true;
                            break;
                        }
                    }      
                }
                else if (Input.GetKey(KeyCode.Mouse1))
                {
                    FIRING_BACKWARD = true;
                    FIRING_FORWARD = false;
                    //Debug.Log("FIRING_BACKWARD :" + FIRING_BACKWARD);

                    for (int i = 0; i < 1000; i++)
                    {
                        if (!shotsAlive[i])
                        {
                            shots[i] = Instantiate(ReverseBeam, gameObject.transform.position, GameObject.Find("First Person Duck Controller").transform.FindChild("Main Camera").transform.rotation) as GameObject;
                            shots[i].transform.SetParent(GameObject.Find("First Person Duck Controller").transform.FindChild("Main Camera").transform);
                            shotsAlive[i] = true;
                            break;
                        }
                    }      
                }
                    

                animator.SetBool("Shoot", true);
                speed = 0.1f;          

            }
            else
            {
                animator.SetBool("Shoot", false);
                speed = 10;

                FIRING_BACKWARD = false;
                FIRING_FORWARD = false;
            }

            for (int i = 0; i < 1000; i++)
            {
                if (shotsAlive[i])
                {
                    shots[i].transform.Translate(0, 0, speed, Space.Self);


                    if (shots[i].transform.FindChild("Beam").transform.GetComponent<BeamBehaviour>().Alive == false)
                    {
                        shotsAlive[i] = false;
                        Destroy(shots[i]);
                    }
                    
                }
            }

        }
	}
}
