using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void toggleFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
