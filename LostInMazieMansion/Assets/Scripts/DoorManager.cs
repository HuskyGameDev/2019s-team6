using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Door", menuName ="GameObject/Door")]
public class DoorManager : ScriptableObject
{
    // which level does this door take us to
    public string roomName;

    // door position
    public float x;
    public float y;
    public float z = 0.0f;
}
