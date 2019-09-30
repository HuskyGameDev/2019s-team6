using System;

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
    internal sealed class PersistentData
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
                    _instance = new PersistentData("TemporarySave");
                }
                return _instance;
            }
        }
        #endregion

        private PersistentData(string saveName)
        {
            SaveName = saveName;
        }

        /// <summary>Name of the current save file.</summary>
        public string SaveName;

        /// <summary>Things that won't be persisted.</summary>
        [NonSerialized]
        public SessionData Volatile = new SessionData
        {
            TargetDoorName = null
        };
    }
}
