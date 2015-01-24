using UnityEngine;
using System.Collections;

public class InitialLevelLoad : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.Find("First Person Duck Controller").transform.FindChild("Main Camera").transform.GetComponent<AudioSource>().Play();
        Application.LoadLevel("FirstRoom");
    }
}
