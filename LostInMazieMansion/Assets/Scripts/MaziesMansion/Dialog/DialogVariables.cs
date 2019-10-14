using System;
using System.Collections.Generic;

namespace MaziesMansion
{
    [Serializable]
    public sealed class DialogVariables: Dictionary<(string storyName, string variableName),object>
    {
        public Dictionary<string, HashSet<string>> StoryKeys = new Dictionary<string, HashSet<string>>();

        public object this[string storyName, string variableName]
        {
            get => this[(storyName, variableName)];
            set => this[(storyName, variableName)] = value;
        }

        public new object this[(string storyName, string variableName) key]
        {
            get => base[key];
            set
            {
                var list = StoryKeys.TryGetValue(key.storyName, out var t) ? t : (StoryKeys[key.storyName] = new HashSet<string>());
                list.Add(key.variableName);
                base[key] = value;
            }
        }

        public bool TryGetValue(string storyName, string variableName, out object value)
            => TryGetValue((storyName, variableName), out value);

        public bool TryGetValue<T>(string storyName, string variableName, out T value)
        {
            var result = TryGetValue((storyName, variableName), out var obj);
            if(result)
                value = (T) obj;
            else
                value = default;
            return result;
        }
    }
}
