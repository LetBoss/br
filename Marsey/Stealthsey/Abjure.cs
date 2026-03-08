using Marsey.Config;

namespace Marsey.Stealthsey;

public static class Abjure
{
    /// <summary>
    /// Checks against version with detection methods
    /// </summary>
    /// <returns>True if version is equal or over with detection and hidesey is disabled</returns>
    public static bool CheckMalbox(string engineversion, HideLevel MarseyHide)
    {
        if (!TryParseEngineVersion(engineversion, out var engineVer))
        {
            return false;
        }

        return engineVer >= MarseyVars.Detection && MarseyHide == HideLevel.Disabled;
    }

    private static bool TryParseEngineVersion(string version, out Version parsed)
    {
        // Some forks expose a non-System.Version suffix (e.g. 7-fix-physics).
        // Use the numeric part when possible instead of crashing the launcher.
        if (Version.TryParse(version, out parsed!))
        {
            return true;
        }

        var sanitized = version.Split('-', '+')[0];
        return Version.TryParse(sanitized, out parsed!);
    }
}
