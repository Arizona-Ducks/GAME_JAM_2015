using UnityEngine;
using System.Collections;

public class GLOBAL_FLAGS : MonoBehaviour
{
    //All flag / global variables will be store in this script attached to the player.
    
    //GLOBAL
    public bool HAS_THE_GEM = false;
    
    //Room_01 (firstRoom)
    public bool IS_THE_NOTE_MISSING = false;
    public bool IS_ARRIVING_FROM_ROOM_03_TO_FIRST_ROOM = false;

    //Room_02
    public int NUMBER_OF_ROOM_02_BUTTONS_PRESSED = 0;
}
