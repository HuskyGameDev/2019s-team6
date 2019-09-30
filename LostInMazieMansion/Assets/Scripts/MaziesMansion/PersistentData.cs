using System;
using UnityEngine;

namespace MaziesMansion
{
    /// <summary>Volatile data that will be persisted across a session, but will not be saved.</summary>
    /// <remarks>
    ///     <p>This is a struct, please go to <see cref="PersistentData.Volatile"/> to set the defaults.</p>
    ///     <p>The advantage is less redirection, but still making it clear that these are not stored values.</p>
    /// </remarks>
    internal struct SessionData
    {
        /// <summary>Target door to move the player object to after loading a scene</summary>
        /// <remarks>Please set this to null once it's been used.</remarks>
        public string TargetDoorName;
    }

    [Serializable]
    [CreateAssetMenu(fileName = "DefaultPersistentData.asset", menuName = "Mazie/Default PersistentData")]
    internal sealed class PersistentData : ScriptableObject
    {
        #region Static Data
        private static PersistentData _instance = null;
        public static PersistentData Instance
        {
            set => _instance = value;
            get
            {
                if(null == _instance)
                {
                    var assets = Resources.FindObjectsOfTypeAll<PersistentData>();
                    if(assets.Length > 0)
                        _instance = assets[0];
                    else
                        _instance = new PersistentData();
                }
                return _instance;
            }
        }
        #endregion

        private PersistentData()
        {
        }

        public void SaveGame() => SaveUtility.SaveGame(this);

        /// <summary>Name of the current save file.</summary>
        public string SaveName = "TemporarySave";

        /// <summary>Things that won't be persisted.</summary>
        [NonSerialized]
        public SessionData Volatile = new SessionData
        {
            TargetDoorName = null
        };

        #region Player Data
        [Tooltip("The player's coordinates in the current scene.")]
        public Vector3 PlayerLocation;

        [Tooltip("The current scene the player is in.")]
        public string CurrentLevel;

        [Tooltip("The player's maximum sanity.")]
        public int MaximumSanity;

        [Tooltip("The player's current sanity.")]
        public int CurrentSanity;
        #endregion
    }
}
