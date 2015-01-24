using UnityEngine;
using System.Collections;

public class SceneChange : MonoBehaviour {
    GameObject player;
    Vector3 playerPos;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update(){}
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player"){
        Debug.Log("error");
            if (Application.loadedLevelName == "FirstRoom" && this.name == "To Room_02")
            {
                playerPos.x = 9;
                playerPos.y = 2;
                playerPos.z = -23;
                Application.LoadLevel("Room_02");
            }
            else if(Application.loadedLevelName == "Room_02" && this.name == "To FirstRoom_00"){
                playerPos.x = 6;
                playerPos.y = 2;
                playerPos.z = 4;
                Application.LoadLevel("FirstRoom");
            }
            else if (Application.loadedLevelName == "Room_02" && this.name == "To Room_03") {
            
            }
            else if (Application.loadedLevelName == "Room_03" && this.name == "To FirstRoom_01")
            {

            }
        }
    }
}