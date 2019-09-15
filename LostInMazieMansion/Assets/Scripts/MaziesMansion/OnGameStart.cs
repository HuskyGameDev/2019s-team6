#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.Rendering;

namespace MaziesMansion
{
    #if UNITY_EDITOR
    [InitializeOnLoad]
    #endif
    /// <summary>Performs actions on runtime initialization/game start</summary>
    internal static class OnGameStart
    {
        static OnGameStart()
        {
            Initialize();
        }

        [RuntimeInitializeOnLoadMethod]
        internal static void Initialize()
        {
            // Set the sort mode to sort by the y-value of the sprite pivot.
            GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
            GraphicsSettings.transparencySortAxis = Vector3.up;
        }
    }
}
