using UnityEngine;

namespace MaziesMansion
{
    [RequireComponent(typeof(Animator))]
    internal sealed class FadeInOut : MonoBehaviour
    {
        private Animator Animator;
        private string NextScene;
        private LevelState LevelState;

        private void Start()
        {
            Animator = GetComponent<Animator>();
            LevelState = LevelState.Instance;
        }
        public void SetPauseState(int onOff)
        {
            LevelState.IsInteractionOpen = onOff > 0;
        }

        public void TriggerTransition(string nextScene)
        {
            NextScene = nextScene;
            LevelState.IsInteractionOpen = true;
            Animator.SetTrigger("OnExitLevel");
        }

        public void PerformTransition()
        {
            LevelState.TransitionToLevelImmediate(NextScene);
        }
    }
}
