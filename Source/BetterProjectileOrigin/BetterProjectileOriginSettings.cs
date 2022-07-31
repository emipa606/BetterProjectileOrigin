using Verse;

namespace BetterProjectileOrigin;

/// <summary>
///     Definition of the settings for the mod
/// </summary>
internal class BetterProjectileOriginSettings : ModSettings
{
    public bool VerboseLogging;

    /// <summary>
    ///     Saving and loading the values
    /// </summary>
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref VerboseLogging, "VerboseLogging");
    }
}