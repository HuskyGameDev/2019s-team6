using TMPro;
using UnityEngine;

namespace MaziesMansion
{
    internal sealed class SaveDataUI: MonoBehaviour
    {
        private PersistentData saveData;
        public TextMeshProUGUI Name = null;
        public void Populate(string savePath)
        {
            saveData = SaveUtility.LoadSave(savePath);
            gameObject.SetActive(true);
            Name.text = saveData.SaveName;
        }

        public void Load()
        {
            Debug.Log("Trying");
            SaveUtility.LoadGame(saveData);
        }
    }
}
