using UnityEngine;

namespace MaziesMansion
{
    internal sealed class PopulateSaveDataUI: MonoBehaviour
    {
        public SaveDataUI[] SaveDataObjects = new SaveDataUI[3];
        private void OnEnable()
        {
            #if UNITY_EDITOR
            if(!Application.isPlaying)
                return;
            #endif

            var i = 0;
            foreach(var path in SaveUtility.GetSaveGamePaths())
            {
                Debug.Log(path);
                if(i >= SaveDataObjects.Length)
                    break;
                SaveDataObjects[i].Populate(path);
                i += 1;
            }
        }
    }
}
