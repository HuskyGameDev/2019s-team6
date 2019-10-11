using System.Text.RegularExpressions;

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
    }
}
