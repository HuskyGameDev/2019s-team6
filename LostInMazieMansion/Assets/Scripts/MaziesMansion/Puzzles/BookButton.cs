using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MaziesMansion
{

    internal sealed class BookButton : MonoBehaviour
    {
        
        public Button book;
        //position for placing books
        private Vector3[] pos = { new Vector3 { x = 336, y = 110, z = 0 },
        new Vector3 { x = 432, y = 110, z = 0},
        new Vector3 { x = 527, y = 110, z = 0},
        new Vector3 { x = 621, y = 110, z = 0} };
        //position for resetting books
        private Vector3[] oldPos = { new Vector3 { x = 336, y = 295, z = 0 },
        new Vector3 { x = 432, y = 295, z = 0},
        new Vector3 { x = 527, y = 295, z = 0},
        new Vector3 { x = 621, y = 295, z = 0} };

        //correct ordeer should be blue - green - red - yellow
        //order sorted alphabetically based on the color 
        private Transform red;
        private Transform blue;
        private Transform yellow;
        private Transform green;

        public UnityEvent OnPuzzleExit;
        public UnityEvent OnPuzzleFailure;

        // Start is called before the first frame update
        void Awake()
        {
            red = GameObject.Find("Red").GetComponent<Transform>();
            blue = GameObject.Find("Blue").GetComponent<Transform>();
            yellow = GameObject.Find("Yellow").GetComponent<Transform>();
            green = GameObject.Find("Green").GetComponent<Transform>();
            PlayerPrefs.SetInt("BookIndex", 0);
        }

        private void Start()
        {
            if (null == OnPuzzleExit)
                OnPuzzleExit = new UnityEvent();
            if (null == OnPuzzleFailure)
                OnPuzzleFailure = new UnityEvent();
            Debug.Log(red.position.x + " " + red.position.y);
            Debug.Log(blue.position.x + " " + blue.position.y);
            Debug.Log(yellow.position.x + " " + yellow.position.y);
            Debug.Log(green.position.x + " " + green.position.y);
        }

        public void ResetPuzzle()
        {
            //reset book index
            PlayerPrefs.SetInt("BookIndex", 0);
        }

        public void onClicked()
        {
            //if a book is clicked
            Debug.Log("Before: " + PlayerPrefs.GetInt("BookIndex"));
            setBooks();
            Debug.Log("After: " + PlayerPrefs.GetInt("BookIndex"));

        }

        private void setBooks()
        {
            //increment book index
            PlayerPrefs.SetInt("BookIndex", PlayerPrefs.GetInt("BookIndex") + 1);
            //place book in new position
            book.transform.position = pos[PlayerPrefs.GetInt("BookIndex") - 1];
            //if the all books are placed and is not at the correct order
            //reset position for all books and reset book index to 0
            if (PlayerPrefs.GetInt("BookIndex") >= pos.Length && !checkOrder())
            {
                PlayerPrefs.SetInt("BookIndex", 0);
                red.position = oldPos[0];
                blue.position = oldPos[1];
                yellow.position = oldPos[2];
                green.position = oldPos[3];
                OnPuzzleFailure.Invoke();
            }
            //if all books are placed and order is correct
            //take next action
            else if (PlayerPrefs.GetInt("BookIndex") == pos.Length && checkOrder())
            {
                Debug.Log("Correct Book Order, action here");
                DialogUtility.SetFlag("F3_Bookshelf_Solved");
                GameObject.Find("Bookshelf Puzzle").SetActive(false);
                OnPuzzleExit.Invoke();
            }
        }

        private bool checkOrder()
        {
            //check if each book is at the right position
            return red.position == pos[2] && blue.position == pos[0]
                && yellow.position == pos[3] && green.position == pos[1];
        }
    }
}
