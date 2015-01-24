using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour 
{
    GLOBAL_FLAGS flags;
    protected Animator animator;
    bool HasFoundTimeGun = false;

	// Use this for initialization
	void Start () 
    {
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
                animator.SetBool("Shoot", true);
            else
                animator.SetBool("Shoot", false);
        }
	}
}
