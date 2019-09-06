using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogSystem : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    public void DisplayMessage()
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
    }

    public void CloseMessage()
    {
        dialogBox.SetActive(false);
    }
}
