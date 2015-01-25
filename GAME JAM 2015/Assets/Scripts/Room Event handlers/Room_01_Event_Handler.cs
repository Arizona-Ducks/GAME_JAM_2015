using UnityEngine;
using System.Collections;

public class Room_01_Event_Handler : MonoBehaviour {

    public GameObject Note;
    public GameObject GunStand;
    GLOBAL_FLAGS flags;

	// Use this for initialization
	void Start () 
    {
        flags = GameObject.Find("First Person Duck Controller").GetComponent<GLOBAL_FLAGS>();

        if (flags.IS_THE_NOTE_MISSING)
            Note.SetActive(false);

        if (flags.HAS_PICKUP_THE_GUN)
        {
            GunStand.transform.FindChild("GeoSphere005").gameObject.SetActive(false);
            GunStand.transform.FindChild("TimeGun").gameObject.SetActive(false);
        }

        if (flags.IS_ARRIVING_FROM_ROOM_03_TO_FIRST_ROOM)
        {
            Transform player = GameObject.Find("First Person Duck Controller").transform;
            Transform spawn = GameObject.Find("FromRoom_03").transform;
            player.Translate(spawn.position - player.position, Space.World);
            flags.IS_ARRIVING_FROM_ROOM_03_TO_FIRST_ROOM = false;
        }
        else if (flags.IS_ARRIVING_FROM_ROOM_08_TO_FIRST_ROOM)
        {
            Transform player = GameObject.Find("First Person Duck Controller").transform;
            Transform spawn = GameObject.Find("FromRoom_08").transform;
            player.Translate(spawn.position - player.position, Space.World);
            flags.IS_ARRIVING_FROM_ROOM_08_TO_FIRST_ROOM = false;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!flags.HAS_PICKUP_THE_GUN && Vector3.Distance(GunStand.transform.position, GameObject.Find("First Person Duck Controller").transform.position) < 1.5f)
            flags.HAS_PICKUP_THE_GUN = true;

        if (flags.HAS_PICKUP_THE_GUN)
        {
            GunStand.transform.FindChild("GeoSphere005").gameObject.SetActive(false);
            GunStand.transform.FindChild("TimeGun").gameObject.SetActive(false);
        }
	}
}
