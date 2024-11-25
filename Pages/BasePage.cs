using Microsoft.Playwright;

/// <summary>
/// Base class for page objects, providing methods for navigation and common actions.
/// </summary>
public abstract class BasePage
{
    protected IPage _page;

    /// <summary>
    /// Initializes a new instance of the BasePage class.
    /// </summary>
    /// <param name="page">The Playwright page instance.</param>
    public BasePage(IPage page)
    {
        _page = page;
    }

    /// <summary>
    /// Navigates to the specified URL and waits for the page to load.
    /// </summary>
    /// <param name="url">The URL to navigate to.</param>
    public async Task NavigateTo(string url)
    {
        await _page.GotoAsync(url);
        await _page.WaitForLoadStateAsync();
    }

    /// <summary>
    /// Waits for the page to finish loading
    /// </summary>
    public async Task FinishedLoadingAsync()
    {
        await _page.WaitForLoadStateAsync();
        await _page.WaitForTimeoutAsync(5000);
    }
}
