using UnityEngine;
using System.Collections;

public class SwitchBehaviour : MonoBehaviour 
{
    GLOBAL_FLAGS flags;
    Transform player;
    const float COOLDOWN = 0.3f;
    float cooldown = 0;
    bool isActionStillPressed = false;
    bool toggled = false;
    Animator animator;

	// Use this for initialization
	void Start () 
    {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
        
        animator = GetComponent<Animator>();
        player = GameObject.Find("First Person Duck Controller").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        Ray playerLookRay = new Ray(player.FindChild("Main Camera").position, player.FindChild("Main Camera").forward);
        RaycastHit hitInfo;

        if (isActionStillPressed && Input.GetAxis("Action") <= 0 && cooldown <= 0)
            isActionStillPressed = false;

        if (cooldown > 0)
            cooldown -= Time.deltaTime;

        if (Input.GetAxis("Action") > 0 && !isActionStillPressed && Vector3.Distance(gameObject.transform.position, player.position) < 3.5f && gameObject.collider.Raycast(playerLookRay, out hitInfo, 10))
        {
            toggled = !toggled;
            cooldown = COOLDOWN;
            isActionStillPressed = true;
            if (toggled)
            {
                animator.SetBool("Pressed", true);
                flags.IS_SWITCH_PRESSED = true;
            }
            else
            {
                animator.SetBool("Pressed", false);
                flags.IS_SWITCH_PRESSED = false;
            }
        }
	}
}
