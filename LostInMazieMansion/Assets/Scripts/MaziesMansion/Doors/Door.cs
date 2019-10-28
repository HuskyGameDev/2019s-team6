using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    [RequireComponent(typeof(Interactable))]
    internal sealed class Door : MonoBehaviour
    {
        public enum Orientation
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }

        public string TargetSceneName = null;
        public string TargetDoorName = null;

        [Tooltip("Orientation of this door (which side is the exit).")]
        public Orientation DoorOrientation = Orientation.LEFT;
        public void Place(GameObject obj)
        {
            var ownPosition = transform.position;
            switch(DoorOrientation)
            {
                case Orientation.UP:
                    obj.transform.position = new Vector2(ownPosition.x, ownPosition.y + 2);
                    break;
                case Orientation.DOWN:
                    obj.transform.position = new Vector2(ownPosition.x, ownPosition.y - 2);
                    break;
                case Orientation.LEFT:
                    obj.transform.position = new Vector2(ownPosition.x - 2, ownPosition.y);
                    break;
                case Orientation.RIGHT:
                    obj.transform.position = new Vector2(ownPosition.x + 2, ownPosition.y);
                    break;
            }
        }
    }
}
