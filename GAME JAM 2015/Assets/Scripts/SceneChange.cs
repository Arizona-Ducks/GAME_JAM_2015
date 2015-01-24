using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
            Application.LoadLevel(this.name.Substring(3));
    }
}