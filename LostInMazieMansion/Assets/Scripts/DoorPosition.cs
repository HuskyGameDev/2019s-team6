using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPosition : MonoBehaviour
{
    public DoorManager door;

    private Transform doorPos;

    private void Start()
    {
        doorPos = GetComponent<Transform>();
        doorPos.transform.position = new Vector3(door.x, door.y, door.z);
    }
}
