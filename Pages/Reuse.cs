using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Playwright;

public class Reuse
{
    public readonly IPage page;
    public Reuse(IPage page)
    {
        this.page = page;
    }   
    public async Task ReuseLogin()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            StorageStatePath = "C:/Users/suba/OneDrive/Documents/Kathir/Handson-20251014T045653Z-1-001.json"
        });
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://practicetestautomation.com/practice-test-login/?utm_source=chatgpt.com");
    }
}