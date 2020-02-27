using System;
using System.Collections.Generic;
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

        /// <summary>Flags if a save game was loaded and we need to restore the player's position.</summary>
        public bool JustLoadedGame;
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
                    _instance = Default;
                return _instance;
            }
        }

        /// <summary>Unity Resources path</summary>
        private const string DefaultSaveDataLocation = "DefaultPersistentData";
        public static PersistentData Default
        {
            get
            {
                var asset = Resources.Load<PersistentData>(DefaultSaveDataLocation);
                if(null != asset)
                    return ScriptableObject.Instantiate(asset);
                Debug.LogError("Could not find default save data");
                return ScriptableObject.CreateInstance<PersistentData>();
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
            TargetDoorName = null,
            JustLoadedGame = false
        };

        #region Player Data
        [Tooltip("The player's coordinates in the current scene.")]
        public Vector3 PlayerLocation = new Vector3(0, 0, int.MinValue); // if z < 0, don't set the player's location

        [Tooltip("The current scene the player is in.")]
        public string CurrentLevel;

        [Tooltip("The player's maximum sanity.")]
        public int MaximumSanity = 80;

        [Tooltip("The player's current sanity.")]
        public int CurrentSanity = int.MaxValue; // if the current > maximum, current will be set to maximum

        [Tooltip("If the flashlight should be turnedon when loading a scene")]
        public bool FlashlightActive = false;
        #endregion

        #region Inventory
        public Inventory Inventory = new Inventory();
        #endregion

        #region Dialog
        public DialogVariables DialogVariables = new DialogVariables();
        public Dictionary<string, string> DialogState = new Dictionary<string, string>();
        #endregion
    }
}
