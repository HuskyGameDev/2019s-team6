using UnityEngine;
using Ink.Runtime;

namespace MaziesMansion
{
    internal sealed class Dialog : MonoBehaviour
    {
        public TextAsset InkJSON = null;

        public string ResumePath = "0";

        private Story _story;

        private void Awake()
        {
            if(null == InkJSON)
                Destroy(this);
            _story = new Story(InkJSON.text);
            var save = PersistentData.Instance;
            if(save.DialogState.TryGetValue(InkJSON.name, out var state))
                _story.state.LoadJson(state);
        }

        public void TriggerStory()
        {
            if(!string.IsNullOrEmpty(ResumePath) && PersistentData.Instance.DialogState.ContainsKey(InkJSON.name))
            {
                _story.state.ForceEnd();
                _story.ChoosePathString(ResumePath);
            }
            FindObjectOfType<DialogManager>().BeginStory(InkJSON.name, _story);
        }
    }
}
