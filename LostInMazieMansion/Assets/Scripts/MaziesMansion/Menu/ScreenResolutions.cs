using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class ScreenResolutions : MonoBehaviour
{
    Resolution[] resolutions;
    public TMP_Dropdown dropdownMenu;
    void Start()
    {
        resolutions = Screen.resolutions;
        dropdownMenu.onValueChanged.AddListener(delegate { Screen.SetResolution(resolutions[dropdownMenu.value].width, resolutions[dropdownMenu.value].height, false); });
        for (int i = 0; i < resolutions.Length; i++)
        {
            dropdownMenu.options[i].text = ResToString(resolutions[i]);
            dropdownMenu.value = i;
            dropdownMenu.options.Add(new TMP_Dropdown.OptionData(dropdownMenu.options[i].text));

        }
    }

    string ResToString(Resolution res)
    {
        return res.width + " x " + res.height;
    }
}
