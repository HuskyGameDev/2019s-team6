using UnityEngine;
using Ink.Runtime;

namespace MaziesMansion
{
    internal sealed class Dialog : MonoBehaviour
    {
        public TextAsset InkJSON = null;

        private Story _story;

        private void Awake()
        {
            if(null == InkJSON)
                Destroy(this);
            _story = new Story(InkJSON.text);
        }

        public void TriggerStory()
        {
            FindObjectOfType<DialogManager>().BeginStory(_story);
        }
    }
}
