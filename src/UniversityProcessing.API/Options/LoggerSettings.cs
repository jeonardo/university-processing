using Serilog;
using Serilog.Configuration;
using Serilog.Events;
using Serilog.Formatting.Compact;
using UniversityProcessing.Utils.Configuration;

namespace UniversityProcessing.API.Options;

public sealed class LoggerSettings : ILoggerSettings, ISettings
{
    /// <summary>
    ///     Minimum log level for the application.
    /// </summary>
    public LogEventLevel MinimumLevel { get; init; }

    /// <summary>
    ///     Overrides for specific namespaces or types.
    /// </summary>
    public Dictionary<string, LogEventLevel> MinimumLevelOverrides { get; init; } = [];

    /// <summary>
    ///     Enables logging to the console.
    /// </summary>
    public bool EnableConsole { get; init; }

    /// <summary>
    ///     Enables logging to a file.
    /// </summary>
    public bool EnableFile { get; init; }

    /// <summary>
    ///     File path for file logging (if enabled).
    /// </summary>
    public string FilePath { get; init; } = string.Empty;

    /// <summary>
    ///     Rolling interval for file logging (e.g., daily, hourly).
    /// </summary>
    public RollingInterval FileRollingInterval { get; init; }

    /// <summary>
    ///     Maximum number of log files to retain. Older files will be deleted.
    /// </summary>
    public int FileRetainedFileCountLimit { get; init; }

    /// <summary>
    ///     Configures the Serilog LoggerConfiguration based on the settings.
    /// </summary>
    /// <param name="loggerConfiguration">The Serilog LoggerConfiguration to configure.</param>
    public void Configure(LoggerConfiguration loggerConfiguration)
    {
        // Set the minimum log level
        loggerConfiguration.MinimumLevel.Is(MinimumLevel);

        // Apply minimum level overrides
        foreach (var @override in MinimumLevelOverrides)
        {
            loggerConfiguration.MinimumLevel.Override(@override.Key, @override.Value);
        }

        // Configure console logging
        if (EnableConsole)
        {
            loggerConfiguration.WriteTo.Console();
        }

        // Configure file logging
        if (EnableFile)
        {
            loggerConfiguration.WriteTo.File(
                new CompactJsonFormatter(),
                FilePath,
                rollingInterval: FileRollingInterval,
                retainedFileCountLimit: FileRetainedFileCountLimit);
        }
    }
}
