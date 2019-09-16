using UnityEngine;
using UnityEngine.UI;

namespace MaziesMansion
{
    [RequireComponent(typeof(Image))]
    internal sealed class HealthUpdater : MonoBehaviour
    {
        [SerializeField]
        private Player Player;
        private Image HealthBar;
        private int _lastHealth;

        private void Start()
        {
            Player = GameObject.FindObjectOfType<Player>();
            HealthBar = GetComponent<Image>();
        }

        private void LateUpdate()
        {
            if(null != Player && Player.CurrentHealth != _lastHealth)
            {
                _lastHealth = Player.CurrentHealth;
                HealthBar.fillAmount = (float)Player.CurrentHealth / Player.MaximumHealth;
            }
        }
    }
}
