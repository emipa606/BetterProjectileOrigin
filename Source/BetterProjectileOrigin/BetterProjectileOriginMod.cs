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
            if (settings == null)
            {
                settings = GetSettings<BetterProjectileOriginSettings>();
            }

            return settings;
        }
        set => settings = value;
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
        var listing_Standard = new Listing_Standard();
        listing_Standard.Begin(rect);
        listing_Standard.Gap();

        listing_Standard.CheckboxLabeled("BPO.verboselogging".Translate(), ref Settings.VerboseLogging,
            "BPO.verboselogging.tooltip".Translate());

        if (currentVersion != null)
        {
            listing_Standard.Gap();
            GUI.contentColor = Color.gray;
            listing_Standard.Label("BPO.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.End();
    }
}