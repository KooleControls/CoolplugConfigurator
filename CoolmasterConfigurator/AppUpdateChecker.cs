namespace CoolmasterConfigurator
{
    public static class AppUpdateChecker
    {
        public static async Task<Version?> CheckForApplicationUpdates()
        {
            Version current = ApplicationIdentity.GetAppVersion();
            var checker = new GithubUpdateChecker("KooleControls", "CoolplugConfigurator");
            var latest = await checker.GetLatestStableVersionAsync();

            return latest > current ? latest : null;
        }
    }



}
