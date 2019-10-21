using FMODUnity;
using UnityEngine;

namespace MaziesMansion
{
    internal sealed class Footsteps: MonoBehaviour
    {
        [EventRef]
        public string FootstepSound;
        private FMODEvent _eventInstance;

        private bool _paused = false;
        public bool Paused
        {
            get => _paused;
            set
            {
                if(_paused != value)
                    _eventInstance.Paused = _paused = value;
            }
        }

        private void Awake()
        {
            _eventInstance = new FMODEvent(FootstepSound);
        }

        private void OnEnable()
        {
            if(null != _eventInstance)
                _eventInstance.Start();
        }

        private void OnDisable()
        {
            if(null != _eventInstance)
                _eventInstance.Stop();
        }
    }
}
