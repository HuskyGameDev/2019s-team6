using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

	public Dialog tableDialog;

	public void TriggerDialogue ()
	{
      
            FindObjectOfType<DialogManager>().StartDialogue(tableDialog);
        		
	}
}
