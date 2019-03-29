/*
 * Holds information about the game.  Alway present.
 * 
 * Doors:
 * remembers the door that was just walked out of
 * used in RoomManager
 */

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DoorManager door;

    public void SetDoor(DoorManager outDoor)
    {
        door = outDoor;
    }

    public DoorManager GetOutDoor()
    {
        return door;
    }

}
