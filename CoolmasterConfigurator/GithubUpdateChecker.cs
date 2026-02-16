using Octokit;

namespace CoolmasterConfigurator
{
    public class GithubUpdateChecker
    {
        private readonly GitHubClient _client;
        private readonly string _owner;
        private readonly string _repo;

        public GithubUpdateChecker(string owner, string repo)
        {
            _owner = owner;
            _repo = repo;
            _client = new GitHubClient(new ProductHeaderValue(repo));
        }

        public async Task<Version> GetLatestStableVersionAsync()
        {
            var releases = await _client.Repository.Release.GetAll(_owner, _repo);

            var stable = releases.FirstOrDefault(r =>
                r != null &&
                !r.Prerelease &&
                !string.IsNullOrWhiteSpace(r.TagName) &&
                TryParseVersion(r.TagName, out _));

            if (stable == null)
                throw new InvalidOperationException("No stable release found.");

            if (!TryParseVersion(stable.TagName, out var latest))
                throw new InvalidOperationException($"Invalid version tag '{stable.TagName}'.");

            return latest;
        }

        private static bool TryParseVersion(string tag, out Version version)
        {
            // Accept "v1.4.0" or "1.4.0"
            var s = tag.StartsWith("v", StringComparison.OrdinalIgnoreCase)
                ? tag.Substring(1)
                : tag;

            // Ignore anything after '-'
            s = s.Split('-')[0];

            return Version.TryParse(s, out version);
        }
    }



}
