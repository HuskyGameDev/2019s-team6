using UnityEngine;

public class DialogTrigger : MonoBehaviour {

	public Dialog tableDialogue;

	public void TriggerDialogue ()
	{

            FindObjectOfType<DialogManager>().StartDialogue(tableDialogue);

	}
}
