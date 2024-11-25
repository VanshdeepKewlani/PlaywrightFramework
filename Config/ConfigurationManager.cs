using System.Text.Json;

/// <summary>
/// Configuration manager for reading settings from the appsettings.json file.
/// </summary>
public static class ConfigurationManager
{
    public static TestSettings Settings { get; private set; }

    static ConfigurationManager()
    {
        var json = File.ReadAllText("Config/appsettings.json");
        Settings = JsonSerializer.Deserialize<TestSettings>(json);
    }

    /// <summary>
    /// Gets the base URL for the application.
    /// </summary>
    /// <returns>The base URL.</returns>
    public static string GetBaseUrl() => Settings.BaseUrl;

    /// <summary>
    /// Gets the timeout value for the tests.
    /// </summary>
    /// <returns>The timeout value in milliseconds.</returns>
    public static int GetTimeout() => Settings.Timeout;

    /// <summary>
    /// Gets the headless mode setting.
    /// </summary>
    /// <returns>A boolean indicating whether the browser should run in headless mode.</returns>
    public static bool GetHeadless() => Settings.Headless;

    /// <summary>
    /// Gets the login credentials for the application.
    /// </summary>
    /// <returns>The credentials object.</returns>
    public static Credentials GetLoginCreds() => Settings.Credentials;
}