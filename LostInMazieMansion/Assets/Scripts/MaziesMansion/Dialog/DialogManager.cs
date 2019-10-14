using UnityEngine;
using Ink.Runtime;
using TMPro;
using System.Collections;

namespace MaziesMansion
{
    internal sealed class DialogManager : MonoBehaviour
    {
        public TextMeshProUGUI Name;
        public TextMeshProUGUI Text;
        public Animator Animator;

        private int TextCharacterCount => Text.GetTextInfo(Text.text).characterCount;

        private Story _story;

        public void BeginStory(Story story)
        {
            Animator.SetBool("IsOpen", true);
            if(null != _story || null != Lines)
                EndStory(closeDialog: false);
            _story = story;
            _story.ResetState();
            AdvanceStory();
        }

        private string[] Lines = null;
        private int CurrentLine = 0;
        public void BeginStory(string actor, string[] lines)
        {
            Animator.SetBool("IsOpen", true);
            if(null != _story || null != Lines)
                EndStory(closeDialog: false);
            Name.text = actor;
            Lines = lines;
            CurrentLine = 0;
            AdvanceStory();
        }

        private IEnumerator _textAnimation;
        public void AdvanceStory()
        {
            if(_textAnimation?.MoveNext() ?? false)
            {
                StopAllCoroutines();
                _textAnimation = null;
                Text.maxVisibleCharacters = TextCharacterCount;
                return;
            }

            if((null != Lines && CurrentLine == Lines.Length) || (null != _story && !_story.canContinue))
            {
                EndStory();
                return;
            }

            if(null != Lines)
            {
                Text.text = Lines[CurrentLine++];
            } else
            {
                var (actor, line) = DialogUtility.GetActorAndLine(_story.Continue());
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
            _textAnimation = null;
            if(null != _story)
            {
                _story = null;
                // TODO: persist story state?
            } else if(null != Lines)
            {
                Lines = null;
                CurrentLine = 0;
            }
        }
    }
}
