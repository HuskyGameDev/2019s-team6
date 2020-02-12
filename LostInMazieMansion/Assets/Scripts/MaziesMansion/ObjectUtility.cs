using UnityEngine;

namespace MaziesMansion
{
    public static class ObjectUtility
    {
        public static bool TryFindObjectOfType<T>(out T obj)
            where T: Object
        {
            obj = GameObject.FindObjectOfType<T>();
            return null != obj;
        }
        public static bool TryFind(string objectName, out GameObject gameObject)
        {
            gameObject = GameObject.Find(objectName);
            return null != gameObject;
        }

        public static bool TryFindComponent<T>(string objectName, out T component)
        {
            if(!TryFind(objectName, out var obj))
            {
                component = default(T);
                return false;
            }
            return obj.TryGetComponent(out component);
        }
    }
}
