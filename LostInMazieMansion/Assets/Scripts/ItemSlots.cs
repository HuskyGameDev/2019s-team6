using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlots : MonoBehaviour
{
    public Button useOrRemove;

    // Start is called before the first frame update
    void Start()
    {
        useOrRemove = GetComponent<Button>();
    }

    private void ButtonClicked()
    {
        Debug.Log("clicked button");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
