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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
                OnPlayerEntered?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.CompareTag("Player"))
                OnPlayerExited?.Invoke();
        }
    }
}
