using UnityEngine;

namespace MaziesMansion
{
    internal sealed class FadeInOut : MonoBehaviour
    {
        public void SetPauseState(int onOff)
        {
            LevelState.Instance.IsInteractionOpen = onOff > 0;
        }
    }
}
