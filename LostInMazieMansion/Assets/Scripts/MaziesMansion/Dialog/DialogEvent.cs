using System;
using UnityEngine.Events;

namespace MaziesMansion
{
    [Serializable]
    internal struct DialogEvent
    {
        public string Name;
        public UnityEvent Actions;
    }
}
