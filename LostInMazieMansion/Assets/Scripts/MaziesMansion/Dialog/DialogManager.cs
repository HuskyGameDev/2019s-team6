using UnityEngine;
using Ink.Runtime;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

namespace MaziesMansion
{
    internal sealed class DialogManager : MonoBehaviour
    {
        public TextMeshProUGUI Name;
        public TextMeshProUGUI Text;
        public Animator Animator;
        public LevelState LevelState;
        public bool isActive;

        private int TextCharacterCount => Text.GetTextInfo(Text.text).characterCount;

        private Story _story;
        private string _storyName;
        private bool _readyToEnd;

        private Dictionary<string, UnityEvent> CurrentEvents = new Dictionary<string, UnityEvent>();

        public void BeginStory(string storyName, Story story, params DialogEvent[] events)
        {
            LevelState.InterfaceState.Open(InterfaceType.Interaction);
            Animator.SetBool("IsOpen", true);
            if(null != _story || null != Lines)
                EndStory(closeDialog: false);
            _story = story;
            _storyName = storyName;
            var save = PersistentData.Instance;
            if(save.DialogVariables.StoryKeys.ContainsKey(_storyName))
                foreach(var key in save.DialogVariables.StoryKeys[_storyName])
                    _story.variablesState[key] = save.DialogVariables[_storyName, key];
            if(null != events)
                foreach(var e in events)
                    if(null != e.Actions)
                        CurrentEvents[e.Name] = e.Actions;
            isActive = true;
            AdvanceStory();
        }

        private string[] Lines = null;
        private int CurrentLine = 0;
        public void BeginStory(string actor, string[] lines)
        {
            LevelState.InterfaceState.Open(InterfaceType.Interaction);
            Animator.SetBool("IsOpen", true);
            if(null != _story || null != Lines)
                EndStory(closeDialog: false);
            Name.text = actor;
            Lines = lines;
            isActive = true;
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

            string text;
            do
            {
                for(text = GetNextLine(); DialogUtility.PerformAction(text, out var actionName, out var actionArgs); text = GetNextLine())
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
                        case "EndAndMovePlayerToDoor":
                            LevelState.TransitionToLevel(actionArgs[0], targetDoor: actionArgs[1]);
                            break;
                        default:
                            if(CurrentEvents.TryGetValue(actionName, out var e))
                                e.Invoke();
                            else if(actionArgs.Length > 0)
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
            } while(_story != null && string.IsNullOrWhiteSpace(text));
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
                while(LevelState.InterfaceState[InterfaceType.PauseMenu | InterfaceType.FadeInOut])
                    yield return new WaitForSeconds(0.3f);
                Text.maxVisibleCharacters = i;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }

        public async void EndStory(bool closeDialog = true)
        {
            
            Animator.SetBool("IsOpen", !closeDialog);
            LevelState.InterfaceState.Toggle(InterfaceType.Interaction);
            StopAllCoroutines();
            CurrentEvents.Clear();
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
            StartCoroutine(WaitToTriggerDialog());
        }

        IEnumerator WaitToTriggerDialog()
        {
            //Print the time of when the function is first called.
            Debug.Log("Started Coroutine at timestamp : " + Time.time);

            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(.01f);
            isActive = false;
            //After we have waited 5 seconds print the time again.
            Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        }

        private void ProcessTags(List<string> tags)
        {
            foreach(var k in tags)
                Debug.Log(k);
        }

        private void Start()
        {
            isActive = false;
        }

        private void Update()
        {
            // If dialogue is open and the player presses e or space
            if (isActive && (Input.GetKeyDown("e") || Input.GetKeyDown("space")))
            {
                // Click continue button
                GameObject.Find("ContinueButton").GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
