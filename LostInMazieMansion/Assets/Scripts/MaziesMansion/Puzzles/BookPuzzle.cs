using UnityEngine;
using UnityEngine.Events;

namespace MaziesMansion
{
    internal enum BookColor
    {

        UNSET = -1,
        RED = 0,
        YELLOW = 1,
        GREEN = 2,
        BLUE = 3
    }

    internal sealed class BookPuzzle : MonoBehaviour, ICloseableUI
    {
        public RectTransform RedBook = null;
        public RectTransform YellowBook = null;
        public RectTransform GreenBook = null;
        public RectTransform BlueBook = null;
        public RectTransform[] ShelfPositions = new RectTransform[4];
        public BookColor[] CorrectOrder = new BookColor[4];

        private int BookIndex = 0;
        private BookColor[] CurrentOrder = new BookColor[4];
        private Vector3[] OriginalPositions = null;
        //correct ordeer should be blue - green - red - yellow
        //order sorted alphabetically based on the color

        public UnityEvent OnPuzzleExit;
        public UnityEvent OnPuzzleFailure;
        private bool InCorrectOrder => CurrentOrder[0] == CorrectOrder[0] && CurrentOrder[1] == CorrectOrder[1] && CurrentOrder[2] == CorrectOrder[2] && CurrentOrder[3] == CorrectOrder[3];
        private bool AllPlaced => BookIndex >= 4;

        private int BottomShelfIndex = 0;
        private void Start()
        {
            if (null == OnPuzzleExit)
                OnPuzzleExit = new UnityEvent();
            if (null == OnPuzzleFailure)
                OnPuzzleFailure = new UnityEvent();
            BookIndex = 0;
            OriginalPositions = new Vector3[4]
            {
                RedBook.position,
                YellowBook.position,
                GreenBook.position,
                BlueBook.position
            };
        }

        public void ResetPuzzle()
        {
            BookIndex = 0;
            CurrentOrder[0] = BookColor.UNSET;
            CurrentOrder[1] = BookColor.UNSET;
            CurrentOrder[2] = BookColor.UNSET;
            CurrentOrder[3] = BookColor.UNSET;
            if(null == OriginalPositions)
                return;
            RedBook.position = OriginalPositions[0];
            YellowBook.position = OriginalPositions[1];
            GreenBook.position = OriginalPositions[2];
            BlueBook.position = OriginalPositions[3];
        }

        public void RedClicked() => OnClicked(BookColor.RED);
        public void GreenClicked() => OnClicked(BookColor.GREEN);
        public void YellowClicked() => OnClicked(BookColor.YELLOW);
        public void BlueClicked() => OnClicked(BookColor.BLUE);

        private void OnClicked(BookColor color)
        {
            CurrentOrder[BookIndex] = color;
            switch(color)
            {
                case BookColor.RED:
                    RedBook.position = ShelfPositions[BookIndex].position;
                    break;
                case BookColor.YELLOW:
                    YellowBook.position = ShelfPositions[BookIndex].position;
                    break;
                case BookColor.GREEN:
                    GreenBook.position = ShelfPositions[BookIndex].position;
                    break;
                case BookColor.BLUE:
                    BlueBook.position = ShelfPositions[BookIndex].position;
                    break;
                default:
                    Debug.LogError("Invalid book color");
                    return;
            }
            BookIndex += 1;
            if(!AllPlaced)
                return;
            if(!InCorrectOrder)
            {
                Debug.Log("Books all on shelf but not in the right order, failure here");
                ResetPuzzle();
                OnPuzzleFailure.Invoke();
                return;
            }
            Debug.Log("Correct Book Order, action here");
            DialogUtility.SetFlag("F3_Bookshelf_Solved");
            Close();
            OnPuzzleExit.Invoke();
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
