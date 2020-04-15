using System;
using System.Collections.Generic;
using UnityEngine;

namespace MaziesMansion
{
    [Serializable]
    internal class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<TKey> keys = null;

        [SerializeField]
        private List<TValue> values = null;

        public void OnBeforeSerialize()
        {
            keys = new List<TKey>(capacity: this.Count);
            values = new List<TValue>(capacity: this.Count);
            foreach(var pair in this)
            {
                keys.Add(pair.Key);
                values.Add(pair.Value);
            }
        }

        public void OnAfterDeserialize()
        {
            Clear();
            if(keys.Count != values.Count)
                throw new Exception("Key and value counts do not match.");
            for(var i = 0; i < keys.Count; i += 1)
                this[keys[i]] = values[i];
            keys = null;
            values = null;
        }
    }
}
