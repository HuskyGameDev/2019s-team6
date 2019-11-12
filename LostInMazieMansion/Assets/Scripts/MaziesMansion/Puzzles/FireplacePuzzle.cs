using UnityEngine;
using UnityEngine.UI;

namespace MaziesMansion
{
    internal sealed class FireplacePuzzle: MonoBehaviour
    {
        [SerializeField]
        private Button[] Targets;

        [HideInInspector]
        public int NextExpectedTarget = 0;

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
                    gameObject.SetActive(false);
                    DialogUtility.SetFlag("F3_Fireplace_Solved");
                }
            } else
            {
                //if wrong order has been clicked, reset status
                //may need to add in some sound effects here to distinguish from
                //correct ordering
                Debug.Log("Wrong target clicked");
                NextExpectedTarget = 0;
            }
        }
    }
}
