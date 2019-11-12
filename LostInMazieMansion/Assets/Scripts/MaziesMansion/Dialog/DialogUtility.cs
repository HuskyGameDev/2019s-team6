using System;
using System.Text.RegularExpressions;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaziesMansion
{
    internal static class DialogUtility
    {
        private static readonly Regex NonActorLine = new Regex(@":\s*$");
        private static readonly Regex ActionText = new Regex(@"^\s*DO::(?<action>\S+)(?:\s+(?<arg>\S+|""[^""]+""))*");
        public static (string actor, string line) GetActorAndLine(string line)
        {
            line = line.Trim();
            var index = line.IndexOf(':', 0);
            if(index < 0 || index == line.Length - 1)
                return ("", line);
            if(index == 0)
                return ("", line.Substring(1).TrimStart());
            for(;;index = line.IndexOf(':', index))
            {
                if(index == line.Length + 1)
                    return ("", line);
                if(line[index - 1] != '\\')
                    return (line.Substring(0, index).TrimEnd(), line.Substring(index + 1).TrimStart());
            }
        }

        public static Story CreateStory(string storyData, DialogEvent[] boundEvents)
        {
            var story = new Story(storyData);
            var save = PersistentData.Instance;
            story.BindExternalFunction<string>("HasItem", name =>
                PersistentData.Instance.Inventory.HasItem(name));
            story.BindExternalFunction<string>("HasCollectedItem", name =>
                PersistentData.Instance.Inventory.HasCollectedItem(name));
            story.BindExternalFunction<string>("HasFlag", name => HasFlag(name));
            story.BindExternalFunction<string>("SetFlag", (Action<string>) SetFlag);
            story.BindExternalFunction<string>("ClearFlag", (Action<string>) ClearFlag);
            foreach(var evt in boundEvents)
                story.BindExternalFunction($"Do{evt.Name}", () => {
                    Debug.Log(evt.Name);
                    evt.Actions?.Invoke();
                });
            return story;
        }

        public static bool HasFlag(string name) => PersistentData.Instance.DialogVariables.Flags.Contains(name);
        public static void SetFlag(string name) => PersistentData.Instance.DialogVariables.Flags.Add(name);
        public static void ClearFlag(string name) => PersistentData.Instance.DialogVariables.Flags.Remove(name);

        public static bool PerformAction(string text, out string actionName, out string[] actionArgs)
        {
            var match = ActionText.Match(text);
            if(!match.Success)
            {
                actionName = null;
                actionArgs = null;
                return false;
            }

            actionName = match.Groups["action"].Value;

            var argCaptures = match.Groups["arg"].Captures;
            actionArgs = new string[argCaptures.Count];
            for(var i = 0; i < actionArgs.Length; i += 1)
            {
                var value = argCaptures[i].Value;
                if(value[0] == '"' && value[value.Length - 1] == '"')
                    value = value.Substring(1, value.Length - 2);
                actionArgs[i] = value;
            }
            return true;
        }
    }
}
