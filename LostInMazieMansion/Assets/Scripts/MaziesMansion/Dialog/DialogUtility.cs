using System.Text.RegularExpressions;
using Ink.Runtime;

namespace MaziesMansion
{
    internal static class DialogUtility
    {
        private static readonly Regex ActorSplitter = new Regex(@"(?:(?<actor>(?:[^:\\]+(?:\\:)*)+)\s*:\s*)?(?<line>.*)");
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
    }
}
