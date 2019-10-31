using UnityEngine;
using UnityEngine.Events;

namespace MaziesMansion
{
    internal sealed class Interactable : MonoBehaviour
    {
        public UnityEvent OnPlayerEntered;
        public UnityEvent OnPlayerExited;
        public UnityEvent OnPlayerInteracts;
        public UnityEvent OnPlayerInspects;

        // Player entering interaction trigger
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
                OnPlayerEntered?.Invoke();
        }

        // Player exiting interaction trigger
        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
                OnPlayerExited?.Invoke();
        }
    }
}
