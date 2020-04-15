using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MaziesMansion
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    internal sealed class SaveDataUI: MonoBehaviour
    {
        private const string EMPTY_SAVE_SLOT = "Empty Save Slot";
        private PersistentData saveData = null;
        private Image Image = null;
        private Button Button = null;

        public TextMeshProUGUI Name = null;
        public SaveSlot SaveSlot;

        public bool SaveMode = false;

        private void Awake()
        {
            Image = GetComponent<Image>();
            Button = GetComponent<Button>();
        }

        private void OnEnable()
        {
            #if UNITY_EDITOR
            if(!Application.isPlaying)
                return;
            #endif

            if(!SaveUtility.TryLoadSave(SaveSlot, out var data))
            {
                Button.interactable = SaveMode; // disable the button if we're not in save mode
                Image.sprite = null;
                Name.text = EMPTY_SAVE_SLOT;
            } else
            {
                saveData = data;
                Button.interactable = true;
                Image.sprite = saveData.SaveData.Image;
                Name.text = saveData.SaveData.Slot.ToString();
            }
        }

        public void Act()
        {
            if(SaveMode)
            {
                saveData = PersistentData.Instance;
                saveData.SaveData.Slot = SaveSlot;
                SaveUtility.SaveGame(saveData);
            } else
            {
                SaveUtility.LoadGame(saveData);
            }
        }
    }
}
