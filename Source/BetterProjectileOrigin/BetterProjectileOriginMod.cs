using Mlie;
using UnityEngine;
using Verse;

namespace BetterProjectileOrigin;

[StaticConstructorOnStartup]
internal class BetterProjectileOriginMod : Mod
{
    private static string currentVersion;

    public static BetterProjectileOriginMod Instance;

    /// <summary>
    ///     The private settings
    /// </summary>
    private BetterProjectileOriginSettings settings;


    /// <summary>
    ///     Cunstructor
    /// </summary>
    /// <param name="content"></param>
    public BetterProjectileOriginMod(ModContentPack content) : base(content)
    {
        Instance = this;
        currentVersion =
            VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    public BetterProjectileOriginSettings Settings
    {
        get
        {
            settings ??= GetSettings<BetterProjectileOriginSettings>();

            return settings;
        }
    }


    /// <summary>
    ///     The title for the mod-settings
    /// </summary>
    /// <returns></returns>
    public override string SettingsCategory()
    {
        return "Better Projectile Origin";
    }

    /// <summary>
    ///     The settings-window
    ///     For more info: https://rimworldwiki.com/wiki/Modding_Tutorials/ModSettings
    /// </summary>
    /// <param name="rect"></param>
    public override void DoSettingsWindowContents(Rect rect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(rect);
        listingStandard.Gap();

        listingStandard.CheckboxLabeled("BPO.verboselogging".Translate(), ref Settings.VerboseLogging,
            "BPO.verboselogging.tooltip".Translate());

        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("BPO.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.End();
    }
}