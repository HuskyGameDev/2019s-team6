using UnityEngine;
using UnityEngine.UI;

namespace MaziesMansion
{
    [RequireComponent(typeof(Image))]
    internal sealed class HealthUpdater : MonoBehaviour
    {
        private Image HealthBar;
        private int _lastHealth;

        public PersistentData CurrentSave;

        private void Start()
        {
            CurrentSave = PersistentData.Instance;
            HealthBar = GetComponent<Image>();
        }

        private void LateUpdate()
        {
            if(CurrentSave.CurrentSanity != _lastHealth)
            {
                _lastHealth = CurrentSave.CurrentSanity;
                HealthBar.fillAmount = (float)CurrentSave.CurrentSanity / CurrentSave.MaximumSanity;
            }
        }
    }
}
