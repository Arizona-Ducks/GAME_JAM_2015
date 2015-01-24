﻿using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

    GLOBAL_FLAGS flags;

    // Use this for initialization
    void Start()
    {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (Application.loadedLevelName == "Room_03" && col.gameObject.tag == "Player" && this.name.Substring(3) == "FirstRoom")
        {
            flags.IS_THE_NOTE_MISSING = true;
            flags.IS_ARRIVING_FROM_ROOM_03_TO_FIRST_ROOM = true;

            Application.LoadLevel(this.name.Substring(3));
        }

        if(col.gameObject.tag == "Player")
            Application.LoadLevel(this.name.Substring(3));
    }
}