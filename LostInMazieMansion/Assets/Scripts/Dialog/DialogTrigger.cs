using UnityEngine;
using MaziesMansion;

public class DialogTrigger : MonoBehaviour {

	public Dialog dialog;

	public void TriggerDialog ()
	{
        FindObjectOfType<DialogManager>().BeginStory(dialog.name, dialog.sentences);
	}
}
