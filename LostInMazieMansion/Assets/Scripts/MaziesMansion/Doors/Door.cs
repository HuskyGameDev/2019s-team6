using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    internal sealed class Door : MonoBehaviour
    {
        public string TargetSceneName = null;
        public string TargetDoorName = null;
        public static Door Instance;

        private void Awake()
        {
            Instance = this;
        }

        [Tooltip("Orientation of this door (which side is the exit).")]
        public Facing DoorOrientation = Facing.LEFT;

        // this is only here so we can toggle the enabled state of the component in the editor
        private void OnEnable(){}

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(!enabled)
                return;
            if(other.tag == "Player")
                LevelState.Instance.TransitionToLevel(TargetSceneName, targetDoor: TargetDoorName);
        }

        public void Place(GameObject obj)
        {
            var ownPosition = transform.position;
            switch(DoorOrientation)
            {
                case Facing.UP:
                    obj.transform.position = new Vector2(ownPosition.x, ownPosition.y + 2);
                    break;
                case Facing.DOWN:
                    obj.transform.position = new Vector2(ownPosition.x, ownPosition.y - 2);
                    break;
                case Facing.LEFT:
                    obj.transform.position = new Vector2(ownPosition.x - 2, ownPosition.y);
                    break;
                case Facing.RIGHT:
                    obj.transform.position = new Vector2(ownPosition.x + 2, ownPosition.y);
                    break;
            }
        }
    }
}
