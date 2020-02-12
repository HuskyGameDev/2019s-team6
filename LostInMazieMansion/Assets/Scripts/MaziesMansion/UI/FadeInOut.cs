using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    /// <summary>
    /// Callbacks and management for the level fade in/out.
    /// </summary>
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

        /// <summary>Starts a fade-out transition to another scene by scene name.</summary>
        public void TriggerTransition(string nextScene)
        {
            NextScene = nextScene;
            LevelState.InterfaceState[InterfaceType.FadeInOut] = true;
            Animator.SetTrigger("OnExitLevel");
        }

        /// <summary>Used by the animator. <paramref cname="onOff"/> is actually a boolean, with 0 being false.</summary>
        public void SetPauseState(int onOff)
        {
            LevelState.InterfaceState[InterfaceType.FadeInOut] = onOff > 0;
        }

        /// <summary>Used by the animator to load the next scene when the fade out animation is complete.</summary>
        public void PerformTransition()
        {
            SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
        }
    }
}
