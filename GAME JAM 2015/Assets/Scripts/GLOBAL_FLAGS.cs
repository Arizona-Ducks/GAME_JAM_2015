using UnityEngine;
using System.Collections;

public class GLOBAL_FLAGS : MonoBehaviour
{
    //All flag / global variables will be store in this script attached to the player.
    
    //GLOBAL
    public bool HAS_PICKUP_THE_GUN = false;
    
    //Room_01 (firstRoom)
    public bool IS_THE_NOTE_MISSING = false;
    public bool IS_ARRIVING_FROM_ROOM_03_TO_FIRST_ROOM = false;
    public bool IS_ARRIVING_FROM_ROOM_08_TO_FIRST_ROOM = false;

    //Room_02
    public int NUMBER_OF_ROOM_02_BUTTONS_PRESSED = 0;
    public bool IS_SWITCH_PRESSED = false;
    public bool IS_BUTTON_03_PRESSED = false;

    //Room_04
    public bool ROOM_04_PUZZLE_FINISHED = false;

    //Room_07
    public bool HAS_PATTERN_PLAYED = false;
    public int NOTE_PRESSED = -1;

    //Room 08
    public bool FINAL_ROOM_BUTTON_PRESSED = false;

}
