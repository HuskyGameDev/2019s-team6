using UnityEngine;
using Ink.Runtime;

namespace MaziesMansion
{
    internal sealed class Dialog : MonoBehaviour
    {
        public TextAsset InkJSON = null;

        /// <remarks>
        /// This will only happen on the very first time the player triggers this.
        /// <b>NOT</b> once per session.
        /// </remarks>
        [Tooltip("The path to start the story at on first run (default is 0).")]
        public string InitialPath = "0";

        [Tooltip("The path to resume the story at on subsequent runs (default is 0).")]
        public string ResumePath = "0";

        public DialogEvent[] Events = new DialogEvent[0];

        private Story _story;

        private void Awake()
        {
            if(null == InkJSON)
                Destroy(this);
            _story = DialogUtility.CreateStory(InkJSON.text);
            var save = PersistentData.Instance;
            if(save.DialogState.TryGetValue(InkJSON.name, out var state))
                _story.state.LoadJson(state);
            else if(!string.IsNullOrEmpty(InitialPath))
                _story.ChoosePathString(InitialPath);
        }

        public void TriggerStory()
        {
            if(!string.IsNullOrEmpty(ResumePath) && PersistentData.Instance.DialogState.ContainsKey(InkJSON.name))
            {
                _story.state.ForceEnd();
                _story.ChoosePathString(ResumePath);
            }
            FindObjectOfType<DialogManager>().BeginStory(InkJSON.name, _story, Events);
        }
    }
}
