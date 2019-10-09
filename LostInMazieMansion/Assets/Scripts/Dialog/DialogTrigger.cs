using UnityEngine;

public class DialogTrigger : MonoBehaviour {

	public Dialog dialog;

	public void TriggerDialog ()
	{

            FindObjectOfType<DialogManager>().StartDialogue(dialog);

	}
}
