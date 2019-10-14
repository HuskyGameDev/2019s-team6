using System.Text.RegularExpressions;
using Ink.Runtime;

namespace MaziesMansion
{
    internal static class DialogUtility
    {
        private static readonly Regex ActorSplitter = new Regex(@"(?:(?<actor>(?:[^:\\]+(?:\\:)*)+)\s*:\s*)?(?<line>.*)");
        private static readonly Regex ActionText = new Regex(@"^\s*DO::(?<action>\S+)(?:\s+(?<arg>\S+|""[^""]+""))*");
        public static (string actor, string line) GetActorAndLine(string line)
        {
            var match = ActorSplitter.Match(line);
            return (match.Groups["actor"]?.Value, match.Groups["line"].Value);
        }

        public static Story CreateStory(string storyData)
        {
            var story = new Story(storyData);
            var save = PersistentData.Instance;
            story.BindExternalFunction<string>("HasItem", name =>
                PersistentData.Instance.Inventory.HasItem(name));
            story.BindExternalFunction<string>("HasCollectedItem", name =>
                PersistentData.Instance.Inventory.HasCollectedItem(name));
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
