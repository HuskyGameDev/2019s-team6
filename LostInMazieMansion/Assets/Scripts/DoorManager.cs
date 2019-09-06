using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Door", menuName ="GameObject/Door")]
public class DoorManager : ScriptableObject
{
    // which door is it
    public string doorName;

    // which level does this door take us to
    public string roomName;

    // which door do we walk through
    public DoorManager connectingDoor;

    // which way do your face when you walk through this door normally
    // on right wall  => door faces LEFT
    // on left wall   => door faces RIGHT
    // on bottom wall => door faces UP
    // on top wall    => door faces DOWN
    public enum Direction {LEFT, UP, RIGHT, DOWN};
    public Direction dir;
}
