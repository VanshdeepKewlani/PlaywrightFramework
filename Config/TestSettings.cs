/// <summary>
/// Class representing the settings used in the application, including environment,
/// base URL, timeout, and login credentials.
/// </summary>
public class TestSettings
{
    public string Environment { get; set; }
    public string BaseUrl { get; set; }
    public int Timeout { get; set; }
    public bool Headless { get; set; }
    public Credentials Credentials { get; set; }
}

/// <summary>
/// Class representing login credentials with username and password.
/// </summary>
public class Credentials
{
    public string Username { get; set; }
    public string Password { get; set; }
}
