using System;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using STOPMODE = FMOD.Studio.STOP_MODE;
using PLAYBACKSTATE = FMOD.Studio.PLAYBACK_STATE;

namespace MaziesMansion
{
    /// <summary>
    /// Wrapper for FMOD sound events with safe parameter control.
    /// </summary>
    public class FMODEvent: IDisposable
    {
        /// <summary>The sound event's instance.</summary>
        public EventInstance EventInstance;

        /// <summary>Get the current playback state.</summary>
        public PLAYBACKSTATE PlaybackState
        {
            get
            {
                var state = default(PLAYBACKSTATE);
                EventInstance.getPlaybackState(out state);
                return state;
            }
        }

        /// <summary>Get if the event is paused.</summary>
        public bool Paused
        {
            get
            {
                var paused = default(bool);
                EventInstance.getPaused(out paused);
                return paused;
            }
            set => EventInstance.setPaused(value);
        }

        /// <summary>Create a new instance given a sound event path.</summary>
        /// <param name="eventPath">A path to a sound event.</param>
        public FMODEvent(string eventPath)
        {
            EventInstance = RuntimeManager.CreateInstance(eventPath);
        }

        /// <summary>Access an event parameter by name.</summary>
        /// <param name="parameterName">The name of the parameter.</param>
        /// <returns>The parameter instance, which is the same between calls.</returns>
        public float this[string parameterName]
        {
            get
            {
                EventInstance.getParameterByName(parameterName, out var value);
                return value;
            }
            set => EventInstance.setParameterByName(parameterName, value);
        }

        /// <summary>Begin playback.</summary>
        public void Start()
            => EventInstance.start();

        /// <summary>Stop playback.</summary>
        public void Stop(STOPMODE mode = STOPMODE.IMMEDIATE)
            => EventInstance.stop(mode);

        /// <summary>Pause or unpause the event.</summary>
        public void SetPaused(bool paused)
            => EventInstance.setPaused(paused);

        /// <summary>Trigger a cue for the event.</summary>
        public void TriggerCue()
            => EventInstance.triggerCue();

        /// <summary>Trigger a cue for the event, leaving any sustain point.</summary>
        public void EndSustain()
            => EventInstance.triggerCue();

        /// <summary>Cleanup resources and stop playback for the event.</summary>
        public void Dispose()
        {
            if (PlaybackState != PLAYBACKSTATE.STOPPED)
                Stop(STOPMODE.IMMEDIATE);
            EventInstance.release();
        }
    }
}
