﻿using UnityEngine;
using System.Collections;

public class InitialLevelLoad : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
	Screen.showCursor = false;
        Application.LoadLevel("FirstRoom");
    }
}
