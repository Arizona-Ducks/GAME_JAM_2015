using UnityEngine;
using System.Collections;

public class GunBehaviour : MonoBehaviour 
{

    protected Animator animator;
	// Use this for initialization
	void Start () 
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Shoot", false);
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1))
            animator.SetBool("Shoot", true);
        else
            animator.SetBool("Shoot", false);
	}
}
