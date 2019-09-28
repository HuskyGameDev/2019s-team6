using System;

namespace MaziesMansion
{
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

        /// <summary>Target door to move the player object to after loading a scene</summary>
        /// <remarks>Please set this to null once it's been used.</remarks>
        [NonSerialized]
        public string TargetDoorName = null;
    }
}
