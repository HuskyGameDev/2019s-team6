using UnityEngine;

namespace MaziesMansion
{
    internal sealed class DirectDialog : MonoBehaviour
    {
        public string Actor;

        [TextArea(3, 10)]
        public string[] Lines = new string[1];

        public void TriggerDialog()
        {
            FindObjectOfType<DialogManager>().BeginStory(Actor, Lines);
        }
    }
}
