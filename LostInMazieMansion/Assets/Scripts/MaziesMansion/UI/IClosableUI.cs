using UnityEngine;

namespace MaziesMansion
{
    public interface ICloseableUI
    {
        void Close();
    }

    internal class CloseableUIObject: ICloseableUI
    {
        private GameObject gameObject;
        public CloseableUIObject(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }
        public void Close() => gameObject.SetActive(false);
    }
}
