using Microsoft.Playwright;
using NUnit.Framework;

public interface IBrowserManager
{
    Task BrowserLaunch();
    Task TearDown();
}
public abstract class BasePage : IBrowserManager
{
    protected IPlaywright? playwright;
    protected IBrowser? browser;
    protected IBrowserContext? context;
    protected IPage? page;

    [SetUp]
    public virtual async Task BrowserLaunch()
    {
        playwright = await Playwright.CreateAsync();
        browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });

        // Create context with video recording enabled
        context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            RecordVideoDir = "C:\\Users\\suba\\OneDrive\\Documents\\Kathir\\Handson-20251014T045653Z-1-001\\Handson\\TestResults\\Videos",
            ViewportSize = new ViewportSize
            {
                Width = 1920,
                Height = 1080
            }
        });

        page = await context.NewPageAsync();

        // Tracing
        await context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
        });
    }

    [TearDown]
    public virtual async Task TearDown()
    {
        if (context != null)
        {
            var traceDir = "C:\\Kathir Automation\\Kathir\\Handson-20251014T045653Z-1-001\\Handson\\TestResults\\Trace";
            Directory.CreateDirectory(traceDir);
            await context.Tracing.StopAsync(new TracingStopOptions
            {
                Path = Path.Combine(traceDir, "Trace.zip")
            });

            await context.CloseAsync();
        }

        if (browser != null)
        {
            await browser.CloseAsync();
        }
        playwright?.Dispose();
    }
}
