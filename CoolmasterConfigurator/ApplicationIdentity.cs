using System.Reflection;

namespace CoolmasterConfigurator
{
    public static class ApplicationIdentity
    {
        static string APPNAME = "Coolmaster configurator";

        public static Version GetAppVersion()
        {
            var asm = Assembly.GetExecutingAssembly();

            // Try informational version first
            var info = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

            if (!string.IsNullOrWhiteSpace(info))
            {
                // Just take numeric part, ignore anything else
                var basePart = info.Split('-')[0];
                if (Version.TryParse(basePart, out var parsed))
                    return parsed;
            }

            // Fallback: assembly version
            var v = asm.GetName().Version ?? new Version(0, 0, 0, 0);
            return new Version(v.Major, v.Minor, v.Build < 0 ? 0 : v.Build);
        }

        public static bool IsPreRelease(Version version)
        {
            // ONLY rule: patch != 0
            return version.Build != 0;
        }

        public static bool IsDebugBuild()
        {
#if DEBUG
            return true;
#else
        return false;
#endif
        }

        public static string GetAppTitle(Version version)
        {
            if (IsDebugBuild())
                return $"{APPNAME} (DEBUG)";

            if (IsPreRelease(version))
                return $"{APPNAME} '{version}' (PRE-RELEASE)";

            return $"{APPNAME} '{version}'";
        }
}



}
