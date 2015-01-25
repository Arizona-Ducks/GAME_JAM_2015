using UnityEngine;
using System.Collections;

public class NoteButton : MonoBehaviour 
{
    GameObject button;
    AudioSource sound;
    GameObject light;

    GLOBAL_FLAGS flags;
    const float COOL_DOWN = 0.3f;
    float cooldown = COOL_DOWN;
	// Use this for initialization
	void Start () 
    {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
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
        switch (button.name)
        {
            case "Button1":
                flags.NOTE_PRESSED = 1;
                break;
            case "Button2":
                flags.NOTE_PRESSED = 2;
                break;
            case "Button3":
                flags.NOTE_PRESSED = 3;
                break;
            case "Button4":
                flags.NOTE_PRESSED = 4;
                break;
        }
    }
}
