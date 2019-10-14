using UnityEngine;
using Ink.Runtime;
using TMPro;
using System.Collections;
using System.Collections.Generic;

namespace MaziesMansion
{
    internal sealed class DialogManager : MonoBehaviour
    {
        public TextMeshProUGUI Name;
        public TextMeshProUGUI Text;
        public Animator Animator;

        private int TextCharacterCount => Text.GetTextInfo(Text.text).characterCount;

        private Story _story;
        private string _storyName;

        public void BeginStory(string storyName, Story story)
        {
            Animator.SetBool("IsOpen", true);
            if(null != _story || null != Lines)
                EndStory(closeDialog: false);
            _story = story;
            _storyName = storyName;
            var save = PersistentData.Instance;
            if(save.DialogVariables.StoryKeys.ContainsKey(_storyName))
                foreach(var key in save.DialogVariables.StoryKeys[_storyName])
                    _story.variablesState[key] = save.DialogVariables[_storyName, key];
            AdvanceStory();
        }

        private string[] Lines = null;
        private int CurrentLine = 0;
        public void BeginStory(string actor, string[] lines)
        {
            Animator.SetBool("IsOpen", true);
            if(null != _story || null != Lines)
                EndStory(closeDialog: false);
            Debug.Log(_story.currentText);
            Name.text = actor;
            Lines = lines;
            AdvanceStory();
        }

        private bool CanContinue => (null != Lines && CurrentLine < Lines.Length) || (null != _story && _story.canContinue);
        private string GetNextLine() => null != Lines ? Lines[CurrentLine++] : _story.Continue();
        private IEnumerator _textAnimation;
        public void AdvanceStory()
        {
            if(null != _textAnimation &&_textAnimation.MoveNext())
            {
                StopAllCoroutines();
                _textAnimation = null;
                Text.maxVisibleCharacters = TextCharacterCount;
                return;
            }

            if(!CanContinue)
            {
                EndStory();
                return;
            }

            var text = GetNextLine();
            for(;DialogUtility.PerformAction(text, out var actionName, out var actionArgs); text = GetNextLine())
            {
                switch(actionName)
                {
                    case "AddItem":
                        var path = actionArgs[0];
                        var item = Resources.Load<InventoryObject>(path);
                        if(null == item)
                            Debug.LogError($"Could not load item from path \"{path}\"");
                        else
                            PersistentData.Instance.Inventory.AddItem(item);
                        break;
                    case "RemoveItem":
                        var itemID = actionArgs[0];
                        PersistentData.Instance.Inventory.RemoveItem(itemID);
                        break;
                    default:
                        if(actionArgs.Length > 0)
                            Debug.LogError($"Unrecognized action \"{actionName}\" with argument(s) \"{string.Join("\", \"", actionArgs)}\"");
                        else
                            Debug.LogError($"Unrecognized action \"{actionName}\"");
                        break;
                }
                if(!CanContinue)
                {
                    EndStory();
                    return;
                }
            }
            if(null != Lines)
            {
                Text.text = text;
            } else
            {
                var (actor, line) = DialogUtility.GetActorAndLine(text);
                Name.text = string.IsNullOrEmpty(actor) ? string.Empty : actor;
                Text.text = line;
            }

            _textAnimation = AnimateText(TextCharacterCount);
            StopAllCoroutines();
            StartCoroutine(_textAnimation);
        }

        private IEnumerator AnimateText(int totalCharacters)
        {
            if(totalCharacters == 0)
                yield break;
            Text.maxVisibleCharacters = 0;
            yield return new WaitForSecondsRealtime(0.3f);
            for(var i = 1; i <= totalCharacters; i += 1)
            {
                Text.maxVisibleCharacters = i;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }

        public void EndStory(bool closeDialog = true)
        {
            Animator.SetBool("IsOpen", !closeDialog);
            StopAllCoroutines();
            _textAnimation = null;
            if(null != _story)
            {
                var save = PersistentData.Instance;
                foreach(var key in _story.variablesState)
                    save.DialogVariables[_storyName, key] = _story.variablesState[key];
                save.DialogState[_storyName] = _story.state.ToJson();
                _story = null;
                _storyName = null;
            } else if(null != Lines)
            {
                Lines = null;
                CurrentLine = 0;
            }
        }

        private void ProcessTags(List<string> tags)
        {
            foreach(var k in tags)
                Debug.Log(k);
        }
    }
}
