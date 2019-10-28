using System.Text.RegularExpressions;
using Ink.Runtime;
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

        public static Story CreateStory(string storyData)
        {
            var story = new Story(storyData);
            var save = PersistentData.Instance;
            story.BindExternalFunction<string>("HasItem", name =>
                PersistentData.Instance.Inventory.HasItem(name));
            story.BindExternalFunction<string>("HasCollectedItem", name =>
                PersistentData.Instance.Inventory.HasCollectedItem(name));
            story.BindExternalFunction<string, string>("EndAndMovePlayerToDoor", (scene, door) => {
                PersistentData.Instance.Volatile.TargetDoorName = door;
                SceneManager.LoadScene(scene, LoadSceneMode.Single);
            });
            return story;
        }

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
                actionArgs[i] = argCaptures[i].Value;
            return true;
        }
    }
}
