using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue tableDialogue;

	public void TriggerDialogue ()
	{
      
            FindObjectOfType<DialogueManager>().StartDialogue(tableDialogue);
        		
	}
}
