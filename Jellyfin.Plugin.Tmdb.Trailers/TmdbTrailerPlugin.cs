using System;
using System.Collections.Generic;
using Jellyfin.Plugin.Tmdb.Trailers.Config;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Common.Plugins;
using MediaBrowser.Model.Plugins;
using MediaBrowser.Model.Serialization;

namespace Jellyfin.Plugin.Tmdb.Trailers;

/// <summary>
/// Plugin entrypoint.
/// </summary>
public class TmdbTrailerPlugin : BasePlugin<PluginConfiguration>, IHasWebPages
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TmdbTrailerPlugin"/> class.
    /// </summary>
    /// <param name="applicationPaths">Instance of the <see cref="IApplicationPaths"/> interface.</param>
    /// <param name="xmlSerializer">Instance of the <see cref="IXmlSerializer"/> interface.</param>
    public TmdbTrailerPlugin(
        IApplicationPaths applicationPaths,
        IXmlSerializer xmlSerializer)
        : base(applicationPaths, xmlSerializer)
    {
        Instance = this;
    }

    /// <summary>
    /// Gets the plugin instance.
    /// </summary>
    public static TmdbTrailerPlugin Instance { get; private set; }

    /// <inheritdoc />
    public override string Name => "TMDb Trailers";

    /// <inheritdoc />
    public override string Description => "Watch movie trailers and extras.";

    /// <inheritdoc />
    public override Guid Id => Guid.Parse("da813c51-c625-482b-9412-7d68f69a5581");

    /// <inheritdoc />
    public IEnumerable<PluginPageInfo> GetPages()
    {
        yield return new PluginPageInfo
        {
            Name = Name,
            EmbeddedResourcePath = $"{GetType().Namespace}.Config.configPage.html"
        };
    }
}
