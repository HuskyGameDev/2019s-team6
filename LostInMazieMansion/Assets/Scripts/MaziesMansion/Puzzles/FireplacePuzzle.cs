using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MaziesMansion
{
    internal sealed class FireplacePuzzle: MonoBehaviour, ICloseableUI
    {
        [SerializeField]
        private Button[] Targets;

        [HideInInspector]
        public int NextExpectedTarget = 0;

        public UnityEvent OnPuzzleExit;
        public UnityEvent OnPuzzleFailure;

        private void Start()
        {
            if(null == OnPuzzleExit)
                OnPuzzleExit = new UnityEvent();
            if(null == OnPuzzleFailure)
                OnPuzzleFailure = new UnityEvent();
        }

        public void ResetPuzzle()
        {
            NextExpectedTarget = 0;
        }

        public void CheckClicked(Button button)
        {
            if(Targets[NextExpectedTarget] == button)
            {
                NextExpectedTarget++;
                Debug.Log($"Correct target {NextExpectedTarget} has been clicked");
                if(NextExpectedTarget >= Targets.Length)
                {
                    Debug.Log("The last target has been clicked, action here");
                    DialogUtility.SetFlag("F3_Fireplace_Solved");
                    Close();
                    OnPuzzleExit.Invoke();
                }
            } else
            {
                //if wrong order has been clicked, reset status
                //may need to add in some sound effects here to distinguish from
                //correct ordering
                Debug.Log("Wrong target clicked");
                OnPuzzleFailure.Invoke();
                NextExpectedTarget = 0;
            }
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            LevelState.Instance.InterfaceState.Open(InterfaceType.Interaction, this);
        }

        private void OnDisable()
        {
            LevelState.Instance?.InterfaceState.Close(InterfaceType.Interaction);
        }
    }
}
