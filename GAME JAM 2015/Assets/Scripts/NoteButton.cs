using UnityEngine;
using System.Collections;

public class NoteButton : MonoBehaviour 
{
    GameObject button;
    AudioSource sound;
    GameObject light;
    const float COOL_DOWN = 0.3f;
    float cooldown = COOL_DOWN;
	// Use this for initialization
	void Start () 
    {
        button = gameObject;
        sound = GetComponent<AudioSource>();
        light = gameObject.transform.FindChild("Spotlight").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            light.GetComponent<Light>().range = 0;
            cooldown = 0;
        }
	}

    public void Play()
    {
        cooldown = COOL_DOWN;
        light.GetComponent<Light>().range = 100;
        sound.Play();
    }

    void OnTriggerEnter(Collider col)
    {
        Play();
    }
}
